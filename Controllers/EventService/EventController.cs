using LetsHang.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Templates;

namespace LetsHang.Controller
{
  [Route("api/v1/[controller]")]
  [ApiController]
  public class EventController : ControllerBase
  {
    private readonly EventContext _context;
    private readonly UserContext _userContext;

    public EventController(EventContext context, UserContext userContext)
    {
      _context = context;
      _userContext = userContext;


      if (_context.Events.Count() == 0) 
      {
        _context.Events.Add( new Event
        {
          Title = "Hang at Pub",
          Description = "Drink our faces off.",
          EventTime = "Right Meow",
          EventLocation = "The Pub on Penn",
          Creator = "Flachman03",
          CreatedAt = DateTime.Now
        });
        _context.Events.Add( new Event
        {
          Title = "Hang out at Home",
          Description = "Watch tv and chill",
          EventTime = "Later Tonight",
          EventLocation = "My House",
          Creator = "Garrett03",
          CreatedAt = DateTime.Now
        });
        _context.Events.Add( new Event
        {
          Title = "Watch christmas movies and get krunk",
          Description = "Home Alone and Home Alone 2!",
          EventTime = "Tonight",
          EventLocation = "Hollywood",
          Creator = "Jacqui03",
          CreatedAt = DateTime.Now
        });
        _context.SaveChanges();

        _context.Invites.Add( new Invited
        {
          UserId = 16,
          FriendId = 17,
          EventId = 6,
          InviteStatus = (InviteStatus)1
        });
        _context.Invites.Add( new Invited
        {
          UserId = 16,
          FriendId = 18,
          EventId = 9,
          InviteStatus = (InviteStatus)1
        });
        _context.Invites.Add( new Invited
        {
          UserId = 16,
          FriendId = 19,
          EventId = 9,
          InviteStatus = (InviteStatus)2
        });
        _context.Invites.Add( new Invited{
          UserId = 16,
          FriendId = 20,
          EventId = 9,
          InviteStatus = (InviteStatus)2
        });

        _context.SaveChanges();
      }
    }

    //==========================================
    //=========================================
    //Get all events from the EventDb
    [HttpGet]
    public ActionResult<List<Event>> GetEvents()
    {
      return _context.Events.ToList();
    }

    //==========================================
    //==========================================
    //Get the users current event that they created
    [HttpGet("current")]
    public ActionResult<EventAndInvited> GetEventByUserName([FromQuery] string ApiKey)
    {
      var user = _userContext.Users
                              .Where( u => u.ApiKey == ApiKey)
                              .FirstOrDefault();

      if( user == null)
        return NotFound("User Not Found");

      var userEvent = _context.Events
                                .Where( e => e.Creator == user.UserName)
                                .FirstOrDefault();

      var invited = _context.Invites
                            .Where( i => i.EventId == userEvent.EventId && i.InviteStatus == (InviteStatus)1)
                            .ToList()
                            .Select( i => _userContext.Users.Find(i.UserId))
                            .Select( u => new PartialUser
                            {
                              UserId = u.UserId,
                              UserName = u.UserName,
                              Name = u.Name,
                              Email = u.Email,
                              PhoneNumber = u.PhoneNumber
                            })
                            .ToList();

      var accepted = _context.Invites
                            .Where( i => i.EventId == userEvent.EventId && i.InviteStatus == (InviteStatus)2)
                            .ToList()
                            .Select( i => _userContext.Users.Find(i.UserId))
                            .Select( u => new PartialUser
                            {
                              UserId = u.UserId,
                              UserName = u.UserName,
                              Name = u.Name,
                              Email = u.Email,
                              PhoneNumber = u.PhoneNumber
                            })
                            .ToList();

      var eventAndInvited = new EventAndInvited
      {
        Event = userEvent,
        Invited = invited,
        Accepted = accepted
      };

      return eventAndInvited;
      
    }

    //====================================
    //====================================
    //Get all events a user has been invited to
    [HttpGet("user/allInvited")]
    public ActionResult<List<EventAndInvited>> AllUserEventsInvitedTo([FromQuery] string ApiKey)
    {
      var user = _userContext.Users
                              .Where( u => u.ApiKey == ApiKey)
                              .FirstOrDefault();

      if (user == null)
        return NotFound();

      var invites = _context.Invites
                            .Where( i => i.FriendId == user.UserId)
                            .ToList();

      var events = new List<Event>();
      foreach( var invite in invites)
      {
        var newEvent = _context.Events.Find(invite.EventId);
        events.Add(newEvent);
      }

      var allEventsAndInvited = new List<EventAndInvited>();
      foreach( var newEvent in events )
      {
        var allInvited = _context.Invites
                                  .Where( i => i.EventId == newEvent.EventId && i.InviteStatus == (InviteStatus)1)
                                  .ToList()
                                  .Select( i => {
                                    var user = _userContext.Users.Find(i.FriendId);
                                    return new PartialUser
                                    {
                                      UserId = user.UserId,
                                      UserName = user.UserName,
                                      Name = user.Name,
                                      Email = user.Email,
                                      PhoneNumber = user.PhoneNumber
                                    };
                                  })
                                  .ToList();

        var allAccepted = _context.Invites
                                  .Where( i => i.EventId == newEvent.EventId && i.InviteStatus == (InviteStatus)2)
                                  .ToList()
                                  .Select( i => {
                                    var user = _userContext.Users.Find(i.FriendId);
                                    return new PartialUser
                                    {
                                      UserId = user.UserId,
                                      UserName = user.UserName,
                                      Name = user.Name,
                                      Email = user.Email,
                                      PhoneNumber = user.PhoneNumber
                                    };
                                  })
                                  .ToList();

        var eventAndInvited = new EventAndInvited 
        {
          Event = newEvent,
          Invited = allInvited,
          Accepted = allAccepted
        };
        allEventsAndInvited.Add(eventAndInvited);
      }

      return allEventsAndInvited;
    }

    //====================================
    //====================================
    //Create a new event
    [HttpPost("{UserId}")]
    public ActionResult<EventAndInvited> AddEvent([FromBody] AddEventTemplates customEvent, long UserId)
    {
      if (!ModelState.IsValid)
        return BadRequest("Invalid data.");

      //Create the new Event object
      var newEvent = new Event
      {
        Title = customEvent.Title,
        Description = customEvent.Description,
        EventTime = customEvent.EventTime,
        EventLocation = customEvent.EventLocation,
        Creator = customEvent.UserName,
        CreatedAt = DateTime.Now
      };

      _context.Events.Add(newEvent);
      _context.SaveChanges();

      //Find the newly created events Id from the EventDb
      //Foreach of the friends invited, create a new invited object and add
      // it to the Invited table in EventDb
      var eventId = _context.Events.Find(newEvent).EventId;
      foreach ( long Id in customEvent.Invited)
      {
        var invited = new Invited
        {
          UserId = UserId,
          FriendId = Id,
          EventId = eventId
        };
        _context.Invites.Add(invited);
      }
      _context.SaveChanges();

      //Find each user by their id in the UserDb and create a 
      // PartialUser object and add it to a list of partial users
      List<PartialUser> allInvited = new List<PartialUser>();

      foreach ( long Id in customEvent.Invited)
      {
        var user = _userContext.Users.Find(Id);

        allInvited.Add( new PartialUser
        {
          UserId = user.UserId,
          UserName = user.UserName,
          Name = user.Name,
          Email = user.Email,
          PhoneNumber = user.PhoneNumber
        });
      }

      //Create and EventAndInvited object to finish out what the user
      // should get back when creating a new event
      var eventAndInvited = new EventAndInvited
      {
        Event = newEvent,
        Invited = allInvited
      };
      return eventAndInvited;
    }

    //==================================
    //==================================
    //Accept an invite to an event
    [HttpPost("accept/{EventId}")]
    public ActionResult AcceptEventInvite([FromQuery] string ApiKey, long EventId)
    {
      var user = _userContext.Users
                              .Where( u => u.ApiKey == ApiKey)
                              .FirstOrDefault();

      if (user == null)
        return NotFound("User Not Found");

      var invite = _context.Invites
                            .Where( i => i.EventId == EventId && i.FriendId == user.UserId)
                            .FirstOrDefault();

      if( invite == null)
        return NotFound("Invite not found for that event");

      invite.InviteStatus = (InviteStatus)2;

      _context.Invites.Update(invite);
      _context.SaveChanges();

      return Ok();
    }

    //====================================
    //====================================
    [HttpPost("AddInvites")]
    public ActionResult AddInvites([FromQuery] string ApiKey, [FromBody] List<long> Invited)
    {
      var user = _userContext.Users
                              .Where( u => u.ApiKey == ApiKey)
                              .FirstOrDefault();

      var userEvent = _context.Events
                                .Where( e => e.Creator == user.UserName)
                                .FirstOrDefault();

      foreach ( long invite in Invited)
      {
        _context.Invites.Add( new Invited
        {
          UserId = user.UserId,
          FriendId = invite,
          EventId = userEvent.EventId,
          InviteStatus = (InviteStatus)1
        });
      }
      
      return Ok();
    }

    //====================================
    //====================================
    //Update a users created event given their ApiKey
    [HttpPatch("{EventId}/{UserId}")]
    public ActionResult<Event> UpdateEvent(long EventId, long UserId, [FromQuery] string ApiKey, [FromBody] Event newEvent)
    {
      var user = _userContext.Users.Find(UserId);

      if (user.ApiKey != ApiKey)
        return BadRequest();

      var userEvent = _context.Events.Find(EventId);

      userEvent.Title = newEvent.Title;
      userEvent.Description = newEvent.Description;
      userEvent.EventTime = newEvent.EventTime;
      userEvent.EventLocation = newEvent.EventLocation;

      _context.Events.Update(userEvent);
      _context.SaveChanges();

      return userEvent;
    }

    //====================================
    //====================================
    //Delete an Event from the EventDb
    [HttpDelete]
    public ActionResult DeleteEvent([FromQuery] string ApiKey)
    {
      var user = _userContext.Users
                              .Where( u => u.ApiKey == ApiKey)
                              .FirstOrDefault();

      if (user == null)
        return NotFound();

      var userEvent = _context.Events
                              .Where( e => e.Creator == user.UserName)
                              .FirstOrDefault();

      if (userEvent == null)
        return NotFound();

      _context.Events.Remove(userEvent);
      _context.SaveChanges();

      return Ok();
    }
  }
}
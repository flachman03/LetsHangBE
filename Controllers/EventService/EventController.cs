using LetsHang.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

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


      if (_context.Events.Count() < 2) 
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

        _context.SaveChanges();
      }
    }

    //Get all events from the EventDb
    [HttpGet]
    public ActionResult<List<Event>> GetEvents()
    {
      return _context.Events.ToList();
    }

    [HttpGet("current")]
    public ActionResult<Event> GetEventByUserName(string username, [FromQuery] string ApiKey)
    {
      var user = _userContext.Users
                              .Where( u => u.ApiKey == ApiKey)
                              .FirstOrDefault();

      if( user == null)
        return NotFound("User Not Found");

      var userEvent = _context.Events
                                .Where( e => e.Creator == user.UserName)
                                .FirstOrDefault();

      return userEvent;
    }
  }
}
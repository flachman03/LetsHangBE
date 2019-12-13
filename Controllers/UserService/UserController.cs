using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System;
using LetsHang.Models;
using Templates;

namespace LetsHang.Controller
{
  [Route("api/v1/[Controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly UserContext _context;

    public UserController( UserContext context)
    {
      _context = context;

      if(_context.Users.Count() == 0)
      {
        _context.Users.Add( new User {
          UserName = "Flachman03",
          Name = "Ryan",
          Email = "user@email.com",
          PhoneNumber = "444444444",
          Password = "password",
          ApiKey = "A93reRTUJHsCuQSHRAL3GxqOJyDmQpCgps102ciuabcA"
        });
        _context.Users.Add( new User
        {
          UserName = "Garrett03",
          Name = "Garrett",
          Email = "user1@email.com",
          PhoneNumber = "444444444",
          Password = "password",
          ApiKey = "B93reRTUJHsCuQSHRCL3GxqOJyDmQpCgps102ciuabc"
        });
        _context.Users.Add( new User{
          UserName = "Jacqui03",
          Name = "Jacqui",
          Email = "user2@email.com",
          PhoneNumber = "444444444",
          Password = "password",
          ApiKey = "C93reRTUJHsCuQSHRXL3GxqOJyDmQpCgps102ciuabc"
        });
        _context.SaveChanges();

      }
      if (_context.Friends.Count() == 0)
      {
        _context.Friends.Add( new Friend
        {
          UserId = 10,
          FriendId = 11,
          RequestStatus = (RequestStatus)2
        });
        _context.Friends.Add( new Friend
        {
          UserId = 10,
          FriendId = 12,
          RequestStatus = (RequestStatus)1
        });
        _context.Friends.Add( new Friend{
          UserId = 10,
          FriendId = 13,
          RequestStatus = (RequestStatus)1
        });
        _context.SaveChanges();
      }
    }

    //Get all users from the UserDb
    [HttpGet]
    public ActionResult<List<User>> GetAllUsers()
    {
      return _context.Users.ToList();
    }

    //Get all Friends from the friends table
    [HttpGet("friends/all")]
    public ActionResult<List<Friend>> GetAllFriends()
    {
      return _context.Friends.ToList();
    }

    //route for user Login with UserName and Password
    [HttpPost("login")]
    public ActionResult<User> LoginUser([FromBody] string UserName, [FromBody] string Password)
    {
      var user = _context.Users
                         .Where( u => u.UserName == UserName && u.Password == Password)
                         .FirstOrDefault();

      if (user == null)
        return NotFound();

      return user;
    }

    [HttpGet("friends")]
    public ActionResult<List<FriendInfo>> GetUserFriends([FromQuery] string ApiKey)
    {
      var user = _context.Users
                          .Where( u => u.ApiKey == ApiKey)
                          .FirstOrDefault();

      if (user == null)
        return NotFound("User Not Found");

      var friendIds = _context.Friends
                                .Where( f => f.UserId == user.UserId)
                                .ToList();

      if (friendIds.Count() == 0)
        return NotFound("No Friend data accociated with the user found");

      var friends = friendIds.Select( f => {
        return _context.Users.Find(f.FriendId);
      }).ToList();

      var friendsInfo = friends.Select( f => {
        return new FriendInfo
        {
          UserName = f.UserName,
          Name = f.Name,
          Email = f.Email,
          PhoneNumber = f.PhoneNumber,
        };
      }).ToList();

      return friendsInfo;
    }

    //Add a new user to the UserDb
    [HttpPost]
    public ActionResult<User> AddUser([FromBody] AddUserTemplates user)
    {
      if (!ModelState.IsValid)
        return BadRequest("Invalid Data");

      if(user.Password != user.ConfirmPassword)
        return BadRequest("Passwords Dont Match");

      var key = new byte[32];
      using (var generator = RandomNumberGenerator.Create())
        generator.GetBytes(key);
      string apiKey = Convert.ToBase64String(key);

      var item = new User {
        Name = user.Name,
        UserName = user.UserName,
        Email = user.Email,
        PhoneNumber = user.PhoneNumber,
        Password = user.Password,
        ApiKey = apiKey
      };

      _context.Add(item);
      _context.SaveChanges();
      return item;
    }

    [HttpPost("Friends/{UserName}")]
    public ActionResult RequestFriendship(string Username, [FromQuery] string ApiKey)
    {
      var user = _context.Users
                          .Where( u => u.ApiKey == ApiKey)
                          .FirstOrDefault();

      if (user == null)
        return NotFound("User not found");

      var friend = _context.Users
                            .Where( u => u.UserName == Username)
                            .FirstOrDefault();

      if (friend == null)
        return NotFound("Friend not found");

      _context.Friends.Add( new Friend
      {
        UserId = user.UserId,
        FriendId = friend.UserId,
        RequestStatus = (RequestStatus)2
      });
      _context.SaveChanges();

      return Ok();
    }

    [HttpPatch("Friends/accept/{UserName}")]
    public ActionResult<Friend> AcceptFriendship([FromQuery] string ApiKey, string UserName)
    {
      var user = _context.Users
                          .Where( u => u.ApiKey == ApiKey)
                          .FirstOrDefault();
      
      if (user == null)
        return NotFound("User Not Found");

      var friend = _context.Users
                            .Where( u => u.UserName == UserName)
                            .FirstOrDefault();

      if (friend == null)
        return NotFound("Friend User Not Found");

      var friendship = _context.Friends
                                .Where( f => f.UserId == user.UserId && f.FriendId == friend.UserId)
                                .FirstOrDefault();

      if (friendship == null)
        return NotFound("Friend Request Not Found");
      
      friendship.RequestStatus = (RequestStatus)1;

      _context.Friends.Update(friendship);
      _context.SaveChanges();

      return friendship;
    }

    //Delete a User by their ApiKey
    [HttpDelete]
    public ActionResult DeleteUser([FromQuery] string ApiKey)
    {
      var user = _context.Users
                          .Where( u => u.ApiKey == ApiKey)
                          .FirstOrDefault();

      if(user == null)
        return NotFound();

      _context.Remove(user);
      _context.SaveChanges();

      return Ok();
    }

    [HttpDelete("Friends/{UserId}/{UserName}")]
    public ActionResult DeleteFriendship(long UserId, string UserName, [FromQuery] string ApiKey)
    {
      var friend = _context.Users
                            .Where( u => u.UserName == UserName)
                            .FirstOrDefault();

      var user = _context.Users
                          .Where( u => u.ApiKey == ApiKey)
                          .FirstOrDefault();

      if (user.UserId != UserId)
        return NotFound();

      var friendship = _context.Friends
                                .Where( f => f.UserId == UserId && f.FriendId == friend.UserId)
                                .FirstOrDefault();
      
      _context.Remove(friendship);
      _context.SaveChanges();

      return Ok();
    }
  }
}
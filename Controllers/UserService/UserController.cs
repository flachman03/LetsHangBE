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

      if(_context.Users.Count()  < 3)
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
    }

    //Get all users from the UserDb
    [HttpGet]
    public ActionResult<List<User>> GetAllUsers()
    {
      return _context.Users.ToList();
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
      return Ok();
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
  }
}
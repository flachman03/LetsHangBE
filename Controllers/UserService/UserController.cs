using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System;
using LetsHang.Models;

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

    [HttpGet]
    public ActionResult<List<User>> GetAllUsers()
    {
      return _context.Users.ToList();
    }

  }
}
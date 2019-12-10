using System.Collections.Generic;
using System.Linq;
using LetsHang.Models;
using Microsoft.AspNetCore.Mvc;

namespace LetsHang.Controller
{
  [Route("api/v1/[controller]")]
  [ApiController]
  public class AdminController : ControllerBase
  {
    private readonly AdminContext _context;
    private readonly UserContext _userContext;
    private readonly EventContext _eventContext;

    public AdminController( AdminContext context, UserContext userContext, EventContext eventContext)
    {
      _context = context;
      _userContext = userContext;
      _eventContext = eventContext;

      if (_context.Admins.Count() == 0)
      {
        _context.Admins.Add( new Admin
        {
          Name = "Ryan Flachman",
          Password = "password"
        });

        _context.SaveChanges();
      }
    }

    [HttpGet]
    public ActionResult<List<Admin>> GetAdmins()
    {
      return _context.Admins.ToList();
    }

    [HttpDelete("friendships/{Id}")]
    public ActionResult AdminDeleteFriendship(long Id, [FromQuery] string Password)
    {
      var admin = _context.Admins
                          .Where( a => a.Password == Password)
                          .FirstOrDefault();

      if ( admin == null)
        return NotFound();
      var friendship = _userContext.Friends.Find(Id);

      _userContext.Friends.Remove(friendship);
      _userContext.SaveChanges();

      return Ok();
    }

    [HttpDelete("users/{Id}")]
    public ActionResult AdminDeleteUser( long Id, [FromQuery] string Password)
    {
      var admin = _context.Admins
                          .Where( a => a.Password == Password)
                          .FirstOrDefault();

      if (admin == null)
        return NotFound();

      var user = _userContext.Users
                              .Where( u => u.UserId == Id)
                              .FirstOrDefault();

      _userContext.Users.Remove(user);
      _userContext.SaveChanges();

      return Ok();
    }
  }
}
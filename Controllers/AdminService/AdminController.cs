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

    public AdminController( AdminContext context)
    {
      _context = context;

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
  }
}
using LetsHang.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace LetsHang.Controller
{
  [Route("api/v1/[controller]")]
  [ApiController]
  public class EventController : ControllerBase
  {
    private readonly EventContext _context;

    public EventController(EventContext context)
    {
      _context = context;

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
  }
}
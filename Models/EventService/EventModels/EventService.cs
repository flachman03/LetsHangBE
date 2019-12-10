using Microsoft.EntityFrameworkCore;

namespace LetsHang.Models
{
  public class EventContext : DbContext
  {
    public EventContext(DbContextOptions<EventContext> options)
    : base(options)
    {
    }

    public DbSet<Event> Events { get; set; }
    public DbSet<Invited> Invites { get; set; }
  }
}
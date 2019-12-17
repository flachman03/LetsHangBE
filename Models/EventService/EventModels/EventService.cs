using Configuration;
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration( new EventConfiguration());
      modelBuilder.ApplyConfiguration( new InvitedConfiguration());
    }
  }
}
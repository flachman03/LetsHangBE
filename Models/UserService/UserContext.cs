using Initializers;
using Microsoft.EntityFrameworkCore;
namespace LetsHang.Models
{
  public class UserContext : DbContext
  {
    public UserContext(DbContextOptions<UserContext> options)
    :base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    public DbSet<Friend> Friends { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new UserConfiguration());
      modelBuilder.ApplyConfiguration(new FriendConfiguration());
    }
  }
}
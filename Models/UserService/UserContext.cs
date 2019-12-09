using Microsoft.EntityFrameworkCore;
using LetsHang.Models;

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
  }
}
using Microsoft.EntityFrameworkCore;
using LetsHang.Models;

namespace LetsHang.Models
{
  public class AdminContext : DbContext
  {
    public AdminContext(DbContextOptions<AdminContext> options)
    :base(options)
    {
    }
    
    public DbSet<Admin> Admins { get; set; }
  }
}
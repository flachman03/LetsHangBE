using System.ComponentModel.DataAnnotations;

namespace LetsHang.Models
{
  public class Admin
  {
    public long Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Password { get; set; }

  }
}
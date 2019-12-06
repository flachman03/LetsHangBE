using System.ComponentModel.DataAnnotations;

namespace LetsHang.Models
{
  public class User
  {
    public long UserId { get; set; }

    [Required]
    public  string UserName { get; set; }
    
    [Required]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [Phone]
    public string PhoneNumber { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public string ApiKey { get; set; }
  }
}
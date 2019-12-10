using System.ComponentModel.DataAnnotations;

namespace Templates
{
  public class PartialUser
  {
    [Required]
    public long UserId { get; set; }

    [Required]
    public string UserName { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string PhoneNumber { get; set; }
  }
}
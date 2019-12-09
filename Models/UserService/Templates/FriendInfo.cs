using System.ComponentModel.DataAnnotations;

namespace Templates
{
  public class FriendInfo
  {
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
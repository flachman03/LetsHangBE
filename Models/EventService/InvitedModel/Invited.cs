using System.ComponentModel.DataAnnotations;

namespace LetsHang.Models
{
  public class Invited
  {
    public long Id { get; set; }

    [Required]
    public long UserId { get; set; }

    [Required]
    public long FriendId { get; set; }

    [Required]
    public long EventId { get; set; }

    [Required]
    public InviteStatus InviteStatus { get; set; }
  }
}
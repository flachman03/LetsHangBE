using System.ComponentModel.DataAnnotations;

namespace LetsHang.Models
{
  public class Friend
  {
    [Required]
    public long UserId { get; set; }

    [Required]
    public long FriendId { get; set; }

    [Required]
    public RequestStatus RequestStatus { get; set; }
  }
    public enum RequestStatus
    {
      Accepted = 1,
      Pending = 2,
      Requested = 3
    }
}
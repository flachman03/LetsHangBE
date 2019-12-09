using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LetsHang.Models;

namespace Templates
{
  public class UserAndFriends
  {
    [Required]
    public User User { get; set; }

    [Required]
    public List<FriendInfo> Friends { get; set; }
  }
}
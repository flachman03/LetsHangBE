using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LetsHang.Models;

namespace Templates
{
  public class EventAndInvited
  {
    [Required]
    public Event Event { get; set; }

    [Required]
    public List<PartialUser> Invited { get; set; }

    public List<PartialUser> Accepted { get; set; }
  }
}
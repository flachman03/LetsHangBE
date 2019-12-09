using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Templates
{
  public class AddEventTemplates
  {
    [Required]
    public long UserId { get; set; }
    
    [Required]
    public string Title { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public string EventTime { get; set; }

    [Required]
    public string EventLocation { get; set; }

    [Required]
    public string UserName { get; set; }

    [Required]
    public List<int> Invited { get; set; }
  }
}
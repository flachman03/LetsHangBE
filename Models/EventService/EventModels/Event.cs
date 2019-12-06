using System;

namespace LetsHang.Models
{
  public class Event
  {
    public long EventId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string EventTime { get; set; }

    public string EventLocation { get; set; }

    public string Creator { get; set; }

    public DateTime CreatedAt { get; set; }

  }
}
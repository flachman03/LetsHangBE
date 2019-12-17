using System;
using LetsHang.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Configuration
{
  public class EventConfiguration : IEntityTypeConfiguration<Event>
  {
    public void Configure(EntityTypeBuilder<Event> builder)
    {
      builder.ToTable("Event");
      builder.HasData(
        new Event
        {
          EventId = 1,
          Title = "Hang at Pub",
          Description = "Drink our faces off.",
          EventTime = "Right Meow",
          EventLocation = "The Pub on Penn",
          Creator = "Flachman03",
          CreatedAt = DateTime.Now
        },
        new Event
        {
          EventId = 2,
          Title = "Hang out at Home",
          Description = "Watch tv and chill",
          EventTime = "Later Tonight",
          EventLocation = "My House",
          Creator = "Garrett03",
          CreatedAt = DateTime.Now
        },
        new Event
        {
          EventId = 3,
          Title = "Watch christmas movies and get krunk",
          Description = "Home Alone and Home Alone 2!",
          EventTime = "Tonight",
          EventLocation = "Hollywood",
          Creator = "Jacqui03",
          CreatedAt = DateTime.Now
        }
      );
    }
  }
}
using System;
using LetsHang.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Templates;

namespace Configuration
{
  public class InvitedConfiguration : IEntityTypeConfiguration<Invited>
  {
    public void Configure(EntityTypeBuilder<Invited> builder)
    {
      builder.ToTable("Invited");
      builder.HasData(
        new Invited
        {
          Id = 1,
          UserId = 1,
          FriendId = 2,
          EventId = 1,
          InviteStatus = (InviteStatus)1
        },
        new Invited
        {
          Id = 2,
          UserId = 1,
          FriendId = 3,
          EventId = 1,
          InviteStatus = (InviteStatus)1
        },
        new Invited
        {
          Id = 3,
          UserId = 1,
          FriendId = 4,
          EventId = 1,
          InviteStatus = (InviteStatus)2
        },
        new Invited 
        {
          Id = 4,
          UserId = 2,
          FriendId = 1,
          EventId = 2,
          InviteStatus = (InviteStatus)1
        },
        new Invited
        {
          Id = 5,
          UserId = 3,
          FriendId = 1,
          EventId = 3,
          InviteStatus = (InviteStatus)1
        }
      );
    }
  }
}
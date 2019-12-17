using LetsHang.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Initializers
{
  public class FriendConfiguration : IEntityTypeConfiguration<Friend>
  {
    public void Configure(EntityTypeBuilder<Friend> builder)
    {
      builder.ToTable("Friend");
      builder.HasData(
        new Friend
        {
          Id = 1,
          UserId = 1,
          FriendId = 2,
          RequestStatus = (RequestStatus)2
        },
        new Friend
        {
          Id = 2,
          UserId = 1,
          FriendId = 3,
          RequestStatus = (RequestStatus)2
        },
        new Friend
        {
          Id = 3,
          UserId = 1,
          FriendId = 4,
          RequestStatus = (RequestStatus)2
        },
        new Friend
        {
          Id = 4,
          UserId = 2,
          FriendId = 3,
          RequestStatus = (RequestStatus)2
        },
        new Friend
        {
          Id = 5,
          UserId = 2,
          FriendId = 3,
          RequestStatus = (RequestStatus)2
        },
        new Friend
        {
          Id = 6,
          UserId = 3,
          FriendId = 4,
          RequestStatus = (RequestStatus)2
        }
      );
    }
  }
}
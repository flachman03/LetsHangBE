using LetsHang.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Initializers
{
  public class UserConfiguration : IEntityTypeConfiguration<User>
  {
    public void Configure(EntityTypeBuilder<User> builder)
    {
      builder.ToTable("User");
      builder.HasData(
        new User
        {
          UserId = 1,
          UserName = "Flachman03",
          Name = "Ryan Flachman",
          Email = "user@email.com",
          PhoneNumber = "1111111111",
          Password = "password",
          ApiKey = "A93reRTUJHsCuQSHRAL3GxqOJyDmQpCgps102ciuabcA"
        },
        new User
        {
          UserId = 2,
          UserName = "Garrett03",
          Name = "Garrett Flachman",
          Email = "user1@email.com",
          PhoneNumber = "2222222222",
          Password = "password",
          ApiKey = "B93reRTUJHsCuQSHRCL3GxqOJyDmQpCgps102ciuabc"
        },
        new User
        {
          UserId = 3,
          UserName = "Jacqui03",
          Name = "Jacqui Long",
          Email = "user2@email.com",
          PhoneNumber = "3333333333",
          Password = "password",
          ApiKey = "C93reRTUJHsCuQSHRXL3GxqOJyDmQpCgps102ciuabc"
        },
        new User
        {
          UserId = 4,
          UserName = "Steve03",
          Name = "Steve Rumizen",
          Email = "user3@email.com",
          PhoneNumber = "5555555555",
          Password = "password",
          ApiKey = "D93reRTUJHsCuQSHRXL3GxqOJyDmQpCgps102ciuabc"
        }
      );
    }
  }
}
using System.Collections.Generic;
using LetsHang.Models;

namespace TestData
{
  public List<User> TestUserData()
  {
    var Users = new List<User>();
    Users.Add( new User
    {
          UserName = "Flachman03",
          Name = "Ryan",
          Email = "user@email.com",
          PhoneNumber = "444444444",
          Password = "password",
          ApiKey = "A93reRTUJHsCuQSHRAL3GxqOJyDmQpCgps102ciuabcA"
    });

    return Users;
  }
}
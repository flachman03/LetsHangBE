using System.Collections.Generic;
using System.Threading.Tasks;
using LetsHang.Controller;
using LetsHang.Models;
using Moq;
using Xunit;
using System.Linq;

public class testclass
{
  private List<User> TestUserData()
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
  
  [Fact]
  public Task GetAllAsync()
  {
    var mockRepo = new Mock<UserContext>();
    mockRepo.Setup(repo => repo.ListAsync());
    var controller = new UserController(mockRepo.Object);

    var result = controller.GetAllUsers();

    Assert.Equal(1, result.Count());
  }
}


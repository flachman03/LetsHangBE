using System.ComponentModel.DataAnnotations;

namespace Templates 
{
  public class LoginUserInfo
  {
    [Required]
    public string Credentials { get; set; }

    [Required]
    public string Password { get; set; }

  }
}
using System;
namespace Sabis.Data
{
  public class UserService:IUserService
  {


    public string Roles
    {
      get;
      set;
    }

    public string FirstName
    {
      get;
      set;
    }
    public string LastName
    {
      get;
      set;
    }

    public string UserId { get; set; }

    public UserService()
    {
      //TODO: set defaults if i have tie i will implement it.
      FirstName = "Mohammad";
      LastName = "khiami";
      UserId = "mkhiami";
      Roles = "Administrator";
    }
  }
}

using System;
namespace Sabis.Data
{
  public interface IUserService
  {
    string Roles { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    string UserId { get; set; }
  }
}

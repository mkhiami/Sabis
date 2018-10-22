using System;
using Microsoft.AspNetCore.Identity;

namespace Sabis.Entities
{
  public class UserInfo : IdentityUser
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }

  }
}

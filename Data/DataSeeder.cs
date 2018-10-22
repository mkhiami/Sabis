using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Sabis.Entities;

namespace Sabis.Data
{
  public class DataSeeder
  {

    private readonly QuestionBankContext _context;
    private readonly IHostingEnvironment _hosting;
    private readonly UserManager<UserInfo> _userManager;

    public DataSeeder(QuestionBankContext ctx, IHostingEnvironment hosting, UserManager<UserInfo> userManager)
    {
      _context = ctx;
      _hosting = hosting;
      _userManager = userManager;
    }

    public async Task SeedAsync()
    {
      _context.Database.EnsureCreated();


      #region First User
      if(_userManager != null){
        UserInfo user = await _userManager.FindByEmailAsync("mkhiami@gmail.com");
        if (user == null)
        {
          user = new UserInfo()
          {
            LastName = "Khiami",
            FirstName = "Mohammad",
            Email = "mkhiami@gmail.com",
            UserName = "mkhiami@gmail.com"
          };
          var result = await _userManager.CreateAsync(user, "khiami@Sabis091");
          if (result != IdentityResult.Success)
          {
            throw new InvalidOperationException("Hyada eli ba3d na2is");
          }



        }

      }
      #endregion
      try
      {
        if (!_context.Subjects.Any())
        {

          _context.Subjects.Add(
            new Subject()
            {
              Description = "Mathmetics",
              Name = "Mathmetics",
              Concepts = new List<Concept>() {
                  new Concept() { Number="M.M.1", Description="Multiplication", Questions = new List<Question>() {
                      new Question(){ Order=1, Description="Question 1", Body="2x2"},  new Question(){ Order=2, Description="Question 2", Body="2x3"}
                }//end questions
                },//end concept
                new Concept() { Number="M.A.1", Description="Addition", Questions = new List<Question>() {
                      new Question(){ Order=1, Description="Question 1.1", Body="2+2"},  new Question(){ Order=2, Description="Question 2.1", Body="2+3"}
                  }//end questions
                }//end concept

          }
            }//end subject
          );//end add



          await _context.SaveChangesAsync();
        }//end subjects any
      }//end try
      catch (Exception ex)
      {

      }//end catch


    }//end seedasync
  }//class
}//namespace
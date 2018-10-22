using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sabis.Entities;

namespace Sabis.Data
{
  public class QuestionBankContext: IdentityDbContext<UserInfo>
  {
    private readonly IUserService _userService;

    public QuestionBankContext()
    {
    }

    #region DBSets
    public DbSet<Subject> Subjects
    {
      get;
      set;
    }

    public DbSet<Concept> Concepts
    {
      get;
      set;
    }

    public DbSet<Question> Questions
    {
      get;
      set;
    }

    public DbSet<Answer> Answers
    {
      get;
      set;
    }
    #endregion


    public QuestionBankContext(DbContextOptions<QuestionBankContext> options, IUserService userService) : base(options)
    {
      // userService is a required argument
      _userService = userService ?? throw new ArgumentNullException(nameof(userService));
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        IConfigurationRoot configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .Build();
        var connectionString = configuration.GetConnectionString("QuestionBankContext");
        optionsBuilder.UseSqlServer(connectionString);
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
    }

    //TODO: add user service and inject it to the context
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken
       = default(CancellationToken))
    {
      // get added or updated entries
      var addedOrUpdatedEntries = ChangeTracker.Entries()
              .Where(x => (x.State == EntityState.Added || x.State == EntityState.Modified));

      // fill out the audit fields
      foreach (var entry in addedOrUpdatedEntries)
      {

        var entity = entry.Entity as BaseEntity;
        if (entity != null)
        { //account for none BaseEntity types

          if (entry.State == EntityState.Added || !entity.Created.HasValue)
          {
            entity.CreatedBy = _userService.UserId;//TODO: fix me
            entity.Created = DateTime.UtcNow;
          }

          entity.ModifiedBy = _userService.UserId; //TODO: fix me
          entity.Modified = DateTime.UtcNow;

        }
      }


      return base.SaveChangesAsync(cancellationToken);
    }

  }
}

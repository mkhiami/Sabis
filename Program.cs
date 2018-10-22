using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Sabis.Data;

namespace Sabis
{
    public class Program
    {
    public static void Main(string[] args)
    {
      var host = BuildWebHost(args);

      SeedDb(host);

      host.Run();
    }

    protected static void SeedDb(IWebHost host)
    {
      var scopeFactory = host.Services.GetService<IServiceScopeFactory>();
      using (var scope = scopeFactory.CreateScope())
      {
        var seeder = scope.ServiceProvider.GetService<DataSeeder>();
        //TODO: fx injection bug
        if(seeder == null){
          seeder = new DataSeeder(new QuestionBankContext(), null, null);
        }
        seeder.SeedAsync().Wait();
      }
    }
    public static IWebHost BuildWebHost(string[] args) =>
     WebHost.CreateDefaultBuilder(args)
         .ConfigureAppConfiguration(SetupConfiguration)
         .UseStartup<Startup>()
         .Build();
    private static void SetupConfiguration(WebHostBuilderContext ctx, IConfigurationBuilder builder)
    {
      builder.Sources.Clear();

      builder.AddJsonFile("appsettings.json", false, true)
             .AddEnvironmentVariables();
    }
  }//end class
}//end NmeSpace
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using Tempalte.Storage;
using Tempalte.Storage.Contexts;

namespace Template.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
          var host = CreateHostBuilder(args).Build();
          using (var scope = host.Services.CreateScope())
          {
              var serviceProvider = scope.ServiceProvider;
              try
              {
                  var context = serviceProvider.GetRequiredService<AppDbContext>();
                  DbInitializer.Initialize(context);
              }
              catch (Exception e)
              {
                  //todo:Exception
                  Console.WriteLine(e);
                  throw;
              }
          }
          host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

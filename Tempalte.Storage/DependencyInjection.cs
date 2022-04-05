using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tempalte.Storage.Contexts;
using Template.Application.Interfaces;
using Template.Domain;

namespace Tempalte.Storage
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddStorage(this IServiceCollection services, 
            IConfiguration configuration)
        {
           
            var databaseName = configuration["DatabaseName"] ?? AddDatabaseName();
            var connectionString = new StringBuilder(configuration["DbConnection"])
                .Append($"Database={databaseName}")
                .ToString();
            services.AddDbContext<AppDbContext>(opt =>
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    opt.UseSqlServer(connectionString);
            });

            try
            {
                AddScopeForEntities(services);
            }
            catch (Exception e)
            {
                //todo exception
                Console.WriteLine($"{e} was given in {nameof(DependencyInjection)} in method {typeof(DependencyInjection).GetMethod(nameof(AddStorage))}");
                throw;
            }

            return services;
        }

        private static string AddDatabaseName()
        {
            var assemblyNameSplit = Assembly.GetExecutingAssembly().FullName?.Split('.');
            return assemblyNameSplit?.Length switch
            {
                1 => $"{assemblyNameSplit[0]}{DateTime.Now}",
                _ => $"{assemblyNameSplit?[0]}"
            };
        }

        private static void AddScopeForEntities(this IServiceCollection services)
        {
            //todo exception
            var assemblyOfEntities = Assembly.GetAssembly(typeof(BaseEntity));
            var entities = assemblyOfEntities
                ?.GetExportedTypes()
                .Where(x => x.GetTypeInfo().BaseType == typeof(BaseEntity)) 
                           ?? throw new Exception("There is no Entities");
            services.AddScoped<IAppDbContext,AppDbContext>();
            //foreach (var entityType in entities)
            //{
            //    var domainInterface = Assembly.GetAssembly(typeof(IAppDbContext))?.GetType(typeof(IAppDbContext)?.FullName ??
            //                                                      throw new Exception(
            //                                                          "IDomainContext is not Found in the Assembly"));
            //    var genericEntityInterface = domainInterface.MakeGenericType(entityType);
            //    services.AddScoped(genericEntityInterface, p => p.GetService(typeof(AppDbContext)));
            //}
        }
    }
}

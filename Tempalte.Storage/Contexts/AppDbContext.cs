using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Template.Application.Interfaces;
using Template.Domain;

namespace Tempalte.Storage.Contexts
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        /// <summary>
        /// Прописываем DbSet в виде свойств
        /// </summary>
        public DbSet<_EntityName_> Names { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseIdentityColumns();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            var dateTimeConverter = new ValueConverter<DateTime, DateTime>(
                v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

            modelBuilder.UseValueConverterForType(typeof(DateTime), dateTimeConverter);

            base.OnModelCreating(modelBuilder);
        }

        //public DbSet<BaseEntity> Context { get; set; }

    }
}

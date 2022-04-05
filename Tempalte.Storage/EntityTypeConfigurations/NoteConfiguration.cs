using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.Domain;

namespace Tempalte.Storage.EntityTypeConfigurations
{
    public class NoteConfiguration : IBaseConfiguration<_EntityName_>
    {
        public void Configure(EntityTypeBuilder<_EntityName_> builder)
        {
            builder.HasKey(n => n.PrimaryId);
            builder.HasIndex(n => n.PrimaryId).IsUnique();
            builder.Property(n => n.Name);
        }
    }
}

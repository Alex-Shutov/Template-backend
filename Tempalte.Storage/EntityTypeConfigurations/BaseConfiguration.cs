using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tempalte.Storage.EntityTypeConfigurations
{
    public interface IBaseConfiguration<T> : IEntityTypeConfiguration<T> where T :class
    {

        public new void Configure(EntityTypeBuilder<T> builder);

    }
}

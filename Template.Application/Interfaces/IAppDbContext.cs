using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Template.Domain;

namespace Template.Application.Interfaces
{
    /// <summary>
    /// В наследниках - дублирование DbSet<Сущности>
    /// </summary>
    public interface IAppDbContext
    {
        DbSet<_EntityName_> Names { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

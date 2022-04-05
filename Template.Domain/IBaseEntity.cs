using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Domain
{
    public abstract class BaseEntity
    {
       public Guid PrimaryId { get; set; }
    }
}

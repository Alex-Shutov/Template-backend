using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Application.Common.Exceptions
{
    public class NotFoundEntityException : Exception
    {
        public NotFoundEntityException(string name, object key) : base(
            $"Entity \"{name}\": key \"{key}\" was not found") {}
    }
}

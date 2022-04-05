using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Application.Common.Exceptions
{
    public class NotImplementedConfigurationException : Exception
    {
        public NotImplementedConfigurationException(string name, object key)
        {

        }
    }
}

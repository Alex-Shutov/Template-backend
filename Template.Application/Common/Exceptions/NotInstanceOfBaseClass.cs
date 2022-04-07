using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Application.Common.Exceptions
{
    public class NotInstanceOfBaseClass : Exception
    {
        public NotInstanceOfBaseClass(Type instanceType, Type baseType) : base($"Class {instanceType} is not based on a {baseType}") {}
    }
}

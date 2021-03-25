using System;
using System.Collections.Generic;
using System.Text;

namespace Phoenix.Attributes
{
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class)]
    public class UseProxyAttribute : Attribute
    {
    }
}

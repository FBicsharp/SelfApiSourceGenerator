using System;
using System.Collections.Generic;
using System.Text;

namespace SelfApiSourceGenerator.Attributes
{
    /// <summary>
    /// Identify if the filed is a database key 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class isKeyFieldApi : Attribute
    {   
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SelfApiSourceGenerator.Attributes
{
    /// <summary>
    /// Identify that filed of dbatabase can be updated-> is used autogenerate put class model
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class UpdateableFieldApi : Attribute
    {   
    }


    
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SelfApiSourceGenerator.Attributes
{
    /// <summary>
    /// Define api mutation from calass generated
    /// warning: if you use this attribute, you must specify all properties
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class GenerateApi : Attribute
    {
        /// <summary>
        /// Api Version
        /// </summary>
        public double Version { get; set; }         
    }   
   

    
}

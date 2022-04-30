using System;
using System.Collections.Generic;
using System.Text;

namespace SelfApiSourceGenerator.Attributes
{

    /// <summary>
    /// Define with endpoint must be generated
    /// warning: if you use this attribute, you must specify all properties
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]    
    public class ExposeEndpoint : Attribute
    {
        public bool Get { get; set; }
        public bool GetByKey { get; set; }
        public bool Post { get; set; }
        public bool Put { get; set; }        
        public bool DeleteByKey { get; set; }
    }

   
   

    
}

using SelfApiSourceGenerator.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SelfApiSourceGenerator.ConstKeyword
{
    internal static  class ConstControllerModel
    {

        #region USING STATEMENT
        internal static  string USING() => @"using Microsoft.AspNetCore.Mvc;";

        #endregion


        #region NAMESPACE STATEMENT
        internal static  string NAMESPACE(string name) => $@"  
             namespace {name}
            {{
            ";

        #endregion

        #region CLASS ATTRIBUTES
        internal static string CLASS_ATTRIBUTES(string ApiVersion="1.0") => $@"  
            [ApiController]
            [Route(""[controller]"")]
            [ApiVersion(""{ApiVersion}"")]            
            ";
        #endregion


        #region CLASS GENERATION STATEMENT
        internal static string CLASS_NAME(string ClassName) => $@"Base_{ClassName}Controller";
        internal static  string CLASS(string ClassName) => $@"              
            public class {CLASS_NAME(ClassName)} : ControllerBase
            {{
            ";
        internal static  string GET_LOGGERS(string ClassName) => $@"  
            private readonly ILogger<{CLASS_NAME(ClassName)}> _logger;
            ";
        internal static string PROPERTIES() => $@"  
            
            ";        

        internal static  string CTOR(string name) => $@"  
            public Base_{name}Controller(ILogger<Base_{name}Controller> logger)
                    {{
                        _logger = logger;
                    }}
            ";

        internal static  string END_CLASS_AND_NAMESPACE ()=> @"  
                }
            }  ";

        #endregion



        //#region  HTTP VERBS METHOD GENERATION STATEMENT


        //internal static  string GET() => @"        
        //[HttpGet]
        //[Route(""GetAll"")]
        //[Produces(""application/json"")]
        //public async Task<IActionResult> GetAll()
        //{
        //    return Ok();
        //}";
        //internal static  string GET_BY_KEY(string paramList) => $@"  
        //[HttpGet]
        //[Route(""GetByKey"")]
        //[Produces(""application/json"")]
        //public async Task<IActionResult> GetByKey({paramList})
        //{{            
        //    return Ok();
        //}}";



        //internal static  string DELETE_BY_KEY(string param) => $@"  
        //[HttpDelete()]
        //[Route(""Delete"")]
        //public async Task<IActionResult> Delete({param})
        //{{
        //    return Ok();//await Mediator.Send(new DeleteProductByIdCommand {{ Id = id }}));
        //}}";

        //internal static  string POST(string paramtype, string parmaname) => $@"  
        //[HttpPost]
        //[Route(""Create"")]
        //public async Task<IActionResult> Create({paramtype} {parmaname})//CreateProductCommand command)
        //{{
        //    return Ok();//await Mediator.Send(command));
        //}}";


        //internal static  string PUT(string paramtype,string parmaname) => $@"  
        //[HttpPut]
        //[Route(""Uodate"")]
        //public async Task<IActionResult> Put({paramtype} {parmaname})//CreateProductCommand command)
        //{{
        //    if ({parmaname} == null)
        //    {{
        //        return BadRequest();
        //    }}
        //    return Ok();//await Mediator.Send(command));
        //}}";
        //#endregion

    }
}


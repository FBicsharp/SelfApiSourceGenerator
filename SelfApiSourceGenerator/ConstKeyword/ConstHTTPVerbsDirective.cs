using SelfApiSourceGenerator.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SelfApiSourceGenerator.ConstKeyword
{
    internal static  class ConstHTTPVerbsDirective
    {
        
        #region  HTTP VERBS METHOD GENERATION STATEMENT


        internal static  string GET() => @"        
        [HttpGet]
        [Route(""GetAll"")]
        [Produces(""application/json"")]
        public async Task<IActionResult> GetAll()
        {
            return Ok();
        }";
        internal static  string GET_BY_KEY(string paramList) => $@"  
        [HttpGet]
        [Route(""GetByKey"")]
        [Produces(""application/json"")]
        public async Task<IActionResult> GetByKey({paramList})
        {{            
            return Ok();
        }}";



        internal static  string DELETE_BY_KEY(string param) => $@"  
        [HttpDelete()]
        [Route(""Delete"")]
        public async Task<IActionResult> Delete({param})
        {{
            return Ok();//await Mediator.Send(new DeleteProductByIdCommand {{ Id = id }}));
        }}";

        internal static  string POST(string paramList) => $@"  
        [HttpPost]
        [Route(""Create"")]
        public async Task<IActionResult> Create({paramList} )//CreateProductCommand command)
        {{
            return Ok();//await Mediator.Send(command));
        }}";


        internal static  string PUT(string paramList) => $@"  
        [HttpPut]
        [Route(""Update"")]
        public async Task<IActionResult> Put({paramList})//CreateProductCommand command)
        {{
            //if ({null/*parmaname*/} == null)
            //{{
            //    return BadRequest();
            //}}
            return Ok();//await Mediator.Send(command));
        }}";
        #endregion

    }
}


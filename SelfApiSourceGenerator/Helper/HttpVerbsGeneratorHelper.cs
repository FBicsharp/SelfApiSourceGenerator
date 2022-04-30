using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SelfApiSourceGenerator.Attributes;
using SelfApiSourceGenerator.ConstKeyword;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SelfApiSourceGenerator.Helper
{
    internal  class HttpVerbsGeneratorHelper
    {

        StringBuilder CurrGeneration { get; set; } = new StringBuilder();

        
        public  HttpVerbsGeneratorHelper Compose_GetByKeyEndpoint(SyntaxTree syntaxTree)
        {
            var properies = syntaxTree.GetRoot().DescendantNodes().OfType<PropertyDeclarationSyntax>();
            //compose of key data
            var keys = string.Empty; //new Dictionary<string, string>();
            var keyscount = 0;
            foreach (var prop in properies)
            {
                if (prop.AttributeLists.ToString().Contains(nameof(isKeyFieldApi)))
                {
                    keyscount++;
                    if (keyscount > 1)
                    {
                        keyscount--;
                        keys += ", ";
                    }
                    //retrive datatype of property
                    var datatype = prop.Type.ToString();
                    var name = prop.Identifier.ToString();
                    keys += $"{datatype} {name} ";
                    //TODO creare un oggetto di filtro
                }
            }
            if (keys.Length > 0)
            {
                CurrGeneration.AppendLine(ConstHTTPVerbsDirective.GET_BY_KEY(keys));
            }                        
            return this;
        }

        public HttpVerbsGeneratorHelper Compose_GetAllEndpoint(SyntaxTree syntaxTree)
        {
            CurrGeneration.AppendLine(ConstHTTPVerbsDirective.GET());
            return this;
        }
        public HttpVerbsGeneratorHelper Compose_DeleteByKeyEndpoint(SyntaxTree syntaxTree)
        {
            var properies = syntaxTree.GetRoot().DescendantNodes().OfType<PropertyDeclarationSyntax>();
            //compose of key data
            var keys = string.Empty; //new Dictionary<string, string>();
            var keyscount = 0;
            foreach (var prop in properies)
            {
                if (prop.AttributeLists.ToString().Contains(nameof(isKeyFieldApi)) && !prop.AttributeLists.ToString().Contains(nameof(NonFieldApi)))
                {
                    keyscount++;
                    if (keyscount > 1)
                    {
                        keyscount--;
                        keys += ", ";
                    }
                    //retrive datatype of property
                    var datatype = prop.Type.ToString();
                    var name = prop.Identifier.ToString();
                    keys += $"{datatype} {name} ";
                    //TODO creare un oggetto di filtro
                }
            }
            if (keys.Length > 0)
            {
                CurrGeneration.AppendLine(ConstHTTPVerbsDirective.DELETE_BY_KEY(keys));
            }
            return this;
            
        }
        public HttpVerbsGeneratorHelper Compose_PostEndpoint(SyntaxTree syntaxTree)
        {
            var properies = syntaxTree.GetRoot().DescendantNodes().OfType<PropertyDeclarationSyntax>();
            //compose of key data
            var keys = string.Empty; //new Dictionary<string, string>();
            var keyscount = 0;
            foreach (var prop in properies)
            {
                if (prop.AttributeLists.ToString().Contains(nameof(CreateRequirdeFieldApi)) && !prop.AttributeLists.ToString().Contains(nameof(NonFieldApi)))
                {
                    keyscount++;
                    if (keyscount > 1)
                    {
                        keyscount--;
                        keys += ", ";
                    }
                    //retrive datatype of property
                    var datatype = prop.Type.ToString();
                    var name = prop.Identifier.ToString();
                    keys += $"{datatype} {name} ";
                    //TODO creare un oggetto di filtro
                }
            }
            if (keys.Length > 0)
            {
                CurrGeneration.AppendLine(ConstHTTPVerbsDirective.POST(keys));
            }            
            return this;
        }
        public HttpVerbsGeneratorHelper Compose_PutEndpoint(SyntaxTree syntaxTree)
        {
            var properies = syntaxTree.GetRoot().DescendantNodes().OfType<PropertyDeclarationSyntax>();
            //compose of key data
            var keys = string.Empty; //new Dictionary<string, string>();
            var keyscount = 0;
            foreach (var prop in properies)
            {
                if (prop.AttributeLists.ToString().Contains(nameof(UpdateableFieldApi)) && !prop.AttributeLists.ToString().Contains(nameof(NonFieldApi)))
                {
                    keyscount++;
                    if (keyscount > 1)
                    {
                        keyscount--;
                        keys += ", ";
                    }
                    //retrive datatype of property
                    var datatype = prop.Type.ToString();
                    var name = prop.Identifier.ToString();
                    keys += $"{datatype} {name} ";
                    //TODO creare un oggetto di filtro
                }
            }
            if (keys.Length > 0)
            {
                CurrGeneration.AppendLine(ConstHTTPVerbsDirective.PUT(keys));
            }            
            return this;
        }
        public string Generate(SyntaxTree syntaxTree,ExposedEnpoint exposedEnpoint)
        {
            if (exposedEnpoint.haveExposeGetEndpoint)
            {
                this.Compose_GetAllEndpoint(syntaxTree);
            }
            if (exposedEnpoint.haveExposeGetByKeyEndpoint)
            {
                this.Compose_GetByKeyEndpoint(syntaxTree);
            }
            if (exposedEnpoint.haveExposeDeleteByKeyEndpoint)
            {
                this.Compose_DeleteByKeyEndpoint(syntaxTree);
            }
            if (exposedEnpoint.haveExposePostEndpoint)
            {
                this.Compose_PostEndpoint(syntaxTree);
            }
            if (exposedEnpoint.haveExposePutEndpoint)
            {
                this.Compose_PutEndpoint(syntaxTree);
            }
            return CurrGeneration.ToString();
        }
    }

    internal class ExposedEnpoint
    {
        public bool haveExposeGetEndpoint {get; set; }
        public bool haveExposeGetByKeyEndpoint {get; set; }
        public bool haveExposePostEndpoint {get; set; }
        public bool haveExposePutEndpoint {get; set; }
        public bool haveExposeDeleteByKeyEndpoint { get; set; }

    }


}

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SelfApiSourceGenerator.Attributes;
using SelfApiSourceGenerator.ConstKeyword;
using SelfApiSourceGenerator.Helper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SelfApiSourceGenerator
{
    [Generator]
    public class SelfApiGenrator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {


            var syntaxTrees = context.Compilation.SyntaxTrees;
            var ControllersToGenerate = syntaxTrees.Where(x => x.GetText().ToString().Contains("["+nameof(GenerateApi))).ToList();

            foreach (var controller in ControllersToGenerate)//scanning for controller that have GenerateApi
            {
                var usingDirective = controller.GetRoot().DescendantNodes().OfType<UsingDirectiveSyntax>();
                var usingDirectivesAsText = string.Join("\r\n", usingDirective);
                StringBuilder sourceBuilder = new StringBuilder(usingDirectivesAsText);                

                var classDeclaration = controller.GetRoot().DescendantNodes().OfType<ClassDeclarationSyntax>().FirstOrDefault();
                var className = classDeclaration.Identifier.ToString();

                #region ATTRIBUTES 

                var classAttributeGenerateapi = classDeclaration.AttributeLists.SelectMany(x => x.Attributes).Where(x => x.Name.ToString().Contains(nameof(GenerateApi))).FirstOrDefault();

                #region DEFINE VERSION

                var apiVersion = classAttributeGenerateapi.ArgumentList.Arguments.Where(x => x.NameEquals.Name.ToString().Contains(nameof(GenerateApi.Version))).FirstOrDefault().Expression.ToString();
                apiVersion = string.IsNullOrEmpty(apiVersion) ? "1.0" : apiVersion;
                var exposedEndpoint = new ExposedEnpoint();
                #endregion
                #region DEFINE HTTP VERBS


                var classAttributeEndpoint = classDeclaration.AttributeLists.SelectMany(x => x.Attributes).Where(x => x.Name.ToString().Contains(nameof(ExposeEndpoint))).FirstOrDefault();

                var ExposeGetEndpointvalue = classAttributeEndpoint.ArgumentList.Arguments.Where(x => x.NameEquals.Name.ToString().Contains(nameof(ExposeEndpoint.Get))).FirstOrDefault().Expression.ToString();
                var ExposeGetByKeyEndpointvalue = classAttributeEndpoint.ArgumentList.Arguments.Where(x => x.NameEquals.Name.ToString().Contains(nameof(ExposeEndpoint.GetByKey))).FirstOrDefault().Expression.ToString();
                var ExposePostEndpointvalue = classAttributeEndpoint.ArgumentList.Arguments.Where(x => x.NameEquals.Name.ToString().Contains(nameof(ExposeEndpoint.Post))).FirstOrDefault().Expression.ToString();
                var ExposePutEndpointvalue = classAttributeEndpoint.ArgumentList.Arguments.Where(x => x.NameEquals.Name.ToString().Contains(nameof(ExposeEndpoint.Put))).FirstOrDefault().Expression.ToString();
                var ExposeDeleteByKeyEndpointvalue = classAttributeEndpoint.ArgumentList.Arguments.Where(x => x.NameEquals.Name.ToString().Contains(nameof(ExposeEndpoint.DeleteByKey))).FirstOrDefault().Expression.ToString();

                exposedEndpoint.haveExposeGetEndpoint = !string.IsNullOrEmpty(ExposeGetEndpointvalue) ? bool.Parse(ExposeGetEndpointvalue) : false;
                exposedEndpoint.haveExposeGetByKeyEndpoint = !string.IsNullOrEmpty(ExposeGetByKeyEndpointvalue) ? bool.Parse(ExposeGetByKeyEndpointvalue) : false;
                exposedEndpoint.haveExposePostEndpoint = !string.IsNullOrEmpty(ExposePostEndpointvalue) ? bool.Parse(ExposePostEndpointvalue) : false;
                exposedEndpoint.haveExposePutEndpoint = !string.IsNullOrEmpty(ExposePutEndpointvalue) ? bool.Parse(ExposePutEndpointvalue) : false;
                exposedEndpoint.haveExposeDeleteByKeyEndpoint = !string.IsNullOrEmpty(ExposeDeleteByKeyEndpointvalue) ? bool.Parse(ExposeDeleteByKeyEndpointvalue) : false;
                #endregion
                #endregion                


                sourceBuilder.AppendLine(KeywordName.AutoGeneratePlaceHolder);
                sourceBuilder.AppendLine(ConstControllerModel.USING());
                sourceBuilder.AppendLine(ConstControllerModel.NAMESPACE("API.Controllers"));
                sourceBuilder.AppendLine(ConstControllerModel.CLASS_ATTRIBUTES(apiVersion));//from attributes
                sourceBuilder.AppendLine(ConstControllerModel.CLASS(className));
                sourceBuilder.AppendLine(ConstControllerModel.GET_LOGGERS(className));
                sourceBuilder.AppendLine(ConstControllerModel.CTOR(className));                
                sourceBuilder.Append(new HttpVerbsGeneratorHelper().Generate(controller, exposedEndpoint));
                sourceBuilder.AppendLine(ConstControllerModel.END_CLASS_AND_NAMESPACE());                
                
                // Add the source code to the compilation
                var new_typecontent = sourceBuilder.ToString();
                context.AddSource(className, new_typecontent);
            }
        }



        public void Initialize(GeneratorInitializationContext context)
        {
            
#if DEBUGSG
            if (!Debugger.IsAttached)
            {
                Debugger.Launch();
            }
#endif
        }
    }

}
#pragma checksum "C:\Users\dojeda\source\repos\MVC_Validation\MVC_Validation\Views\Friends\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3f45c67c2e20ad6172de137473a53c9d7221445a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Friends_Create), @"mvc.1.0.view", @"/Views/Friends/Create.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Friends/Create.cshtml", typeof(AspNetCore.Views_Friends_Create))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\dojeda\source\repos\MVC_Validation\MVC_Validation\Views\_ViewImports.cshtml"
using MVC_Validation;

#line default
#line hidden
#line 2 "C:\Users\dojeda\source\repos\MVC_Validation\MVC_Validation\Views\_ViewImports.cshtml"
using MVC_Validation.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3f45c67c2e20ad6172de137473a53c9d7221445a", @"/Views/Friends/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6eaed65f956aa111e60aecd8d09ebee3b8952ab8", @"/Views/_ViewImports.cshtml")]
    public class Views_Friends_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MVC_Validation.Models.Friend>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/friends/create"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\dojeda\source\repos\MVC_Validation\MVC_Validation\Views\Friends\Create.cshtml"
  
    ViewData["Title"] = "Create";

#line default
#line hidden
            BeginContext(79, 19, true);
            WriteLiteral("\r\n<h1>Create</h1>\r\n");
            EndContext();
            BeginContext(99, 24, false);
#line 7 "C:\Users\dojeda\source\repos\MVC_Validation\MVC_Validation\Views\Friends\Create.cshtml"
Write(Html.ValidationSummary());

#line default
#line hidden
            EndContext();
            BeginContext(123, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(127, 878, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3f45c67c2e20ad6172de137473a53c9d7221445a4568", async() => {
                BeginContext(172, 42, true);
                WriteLiteral("\r\n    Name: <input type=\"text\" name=\"name\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 214, "\"", 233, 1);
#line 10 "C:\Users\dojeda\source\repos\MVC_Validation\MVC_Validation\Views\Friends\Create.cshtml"
WriteAttributeValue("", 222, Model.Name, 222, 11, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(234, 9, true);
                WriteLiteral(" />\r\n    ");
                EndContext();
                BeginContext(244, 30, false);
#line 11 "C:\Users\dojeda\source\repos\MVC_Validation\MVC_Validation\Views\Friends\Create.cshtml"
Write(Html.ValidationMessage("name"));

#line default
#line hidden
                EndContext();
                BeginContext(274, 53, true);
                WriteLiteral("\r\n    <br />\r\n    Age:  <input type=\"text\" name=\"age\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 327, "\"", 345, 1);
#line 13 "C:\Users\dojeda\source\repos\MVC_Validation\MVC_Validation\Views\Friends\Create.cshtml"
WriteAttributeValue("", 335, Model.Age, 335, 10, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(346, 9, true);
                WriteLiteral(" />\r\n    ");
                EndContext();
                BeginContext(356, 29, false);
#line 14 "C:\Users\dojeda\source\repos\MVC_Validation\MVC_Validation\Views\Friends\Create.cshtml"
Write(Html.ValidationMessage("age"));

#line default
#line hidden
                EndContext();
                BeginContext(385, 58, true);
                WriteLiteral("\r\n    <br />\r\n    email:  <input type=\"email\" name=\"email\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 443, "\"", 463, 1);
#line 16 "C:\Users\dojeda\source\repos\MVC_Validation\MVC_Validation\Views\Friends\Create.cshtml"
WriteAttributeValue("", 451, Model.Email, 451, 12, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(464, 9, true);
                WriteLiteral(" />\r\n    ");
                EndContext();
                BeginContext(474, 31, false);
#line 17 "C:\Users\dojeda\source\repos\MVC_Validation\MVC_Validation\Views\Friends\Create.cshtml"
Write(Html.ValidationMessage("email"));

#line default
#line hidden
                EndContext();
                BeginContext(505, 66, true);
                WriteLiteral("\r\n    <br />\r\n    Street: <input type=\"text\" name=\"Address.Street\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 571, "\"", 600, 1);
#line 19 "C:\Users\dojeda\source\repos\MVC_Validation\MVC_Validation\Views\Friends\Create.cshtml"
WriteAttributeValue("", 579, Model.Address.Street, 579, 21, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(601, 9, true);
                WriteLiteral(" />\r\n    ");
                EndContext();
                BeginContext(611, 40, false);
#line 20 "C:\Users\dojeda\source\repos\MVC_Validation\MVC_Validation\Views\Friends\Create.cshtml"
Write(Html.ValidationMessage("Address.Street"));

#line default
#line hidden
                EndContext();
                BeginContext(651, 63, true);
                WriteLiteral("\r\n    <br />\r\n    City:  <input type=\"text\" name=\"Address.City\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 714, "\"", 741, 1);
#line 22 "C:\Users\dojeda\source\repos\MVC_Validation\MVC_Validation\Views\Friends\Create.cshtml"
WriteAttributeValue("", 722, Model.Address.City, 722, 19, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(742, 9, true);
                WriteLiteral(" />\r\n    ");
                EndContext();
                BeginContext(752, 38, false);
#line 23 "C:\Users\dojeda\source\repos\MVC_Validation\MVC_Validation\Views\Friends\Create.cshtml"
Write(Html.ValidationMessage("Address.City"));

#line default
#line hidden
                EndContext();
                BeginContext(790, 68, true);
                WriteLiteral("\r\n    <br />\r\n    Zipcode: <input type=\"text\" name=\"Address.ZipCode\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 858, "\"", 888, 1);
#line 25 "C:\Users\dojeda\source\repos\MVC_Validation\MVC_Validation\Views\Friends\Create.cshtml"
WriteAttributeValue("", 866, Model.Address.ZipCode, 866, 22, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(889, 9, true);
                WriteLiteral(" />\r\n    ");
                EndContext();
                BeginContext(899, 41, false);
#line 26 "C:\Users\dojeda\source\repos\MVC_Validation\MVC_Validation\Views\Friends\Create.cshtml"
Write(Html.ValidationMessage("Address.ZipCode"));

#line default
#line hidden
                EndContext();
                BeginContext(940, 58, true);
                WriteLiteral("\r\n    <br />\r\n\r\n    <input type=\"submit\" value=\"Submit\">\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MVC_Validation.Models.Friend> Html { get; private set; }
    }
}
#pragma warning restore 1591

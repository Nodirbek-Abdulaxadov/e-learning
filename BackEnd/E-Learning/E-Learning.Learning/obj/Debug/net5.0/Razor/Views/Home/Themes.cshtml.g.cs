#pragma checksum "E:\OWN\E-Learning\BackEnd\E-Learning\E-Learning.Learning\Views\Home\Themes.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ccb77c98a00617b39407bfd724b0b5bcce8aa265"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Themes), @"mvc.1.0.view", @"/Views/Home/Themes.cshtml")]
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
#nullable restore
#line 1 "E:\OWN\E-Learning\BackEnd\E-Learning\E-Learning.Learning\Views\_ViewImports.cshtml"
using E_Learning.Learning;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\OWN\E-Learning\BackEnd\E-Learning\E-Learning.Learning\Views\_ViewImports.cshtml"
using E_Learning.ViewModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\OWN\E-Learning\BackEnd\E-Learning\E-Learning.Learning\Views\_ViewImports.cshtml"
using E_Learning.Domain;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ccb77c98a00617b39407bfd724b0b5bcce8aa265", @"/Views/Home/Themes.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2076f24ad3f96ce7096c49ff78c747174fc0b112", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Themes : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IndexViewModel>
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\OWN\E-Learning\BackEnd\E-Learning\E-Learning.Learning\Views\Home\Themes.cshtml"
  
    ViewData["Title"] = "Theme Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div style=\"margin-top: -3rem;\">\r\n    <div class=\"p-4\">\r\n        <div class=\"card-body mx-3\">\r\n            \r\n            <div class=\"row\">\n");
#nullable restore
#line 11 "E:\OWN\E-Learning\BackEnd\E-Learning\E-Learning.Learning\Views\Home\Themes.cshtml"
                 foreach (var item in Model.Courses)
               {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"col-md-6 p-3\">\r\n                        <div class=\"card\">\r\n                            <div class=\"card-body\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ccb77c98a00617b39407bfd724b0b5bcce8aa2654123", async() => {
#nullable restore
#line 16 "E:\OWN\E-Learning\BackEnd\E-Learning\E-Learning.Learning\Views\Home\Themes.cshtml"
                                                            Write(item.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 466, "~/Pages/", 466, 8, true);
#nullable restore
#line 16 "E:\OWN\E-Learning\BackEnd\E-Learning\E-Learning.Learning\Views\Home\Themes.cshtml"
AddHtmlAttributeValue("", 474, item.PageLink, 474, 14, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                    </div>\n");
#nullable restore
#line 20 "E:\OWN\E-Learning\BackEnd\E-Learning\E-Learning.Learning\Views\Home\Themes.cshtml"
               }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>        \r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591

#pragma checksum "D:\DotNetCore\Karaoke\Karaoke\Views\Shared\_MenuAdmin.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b06d49fea46f16f1153e84e290e8a6fb301eb516"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__MenuAdmin), @"mvc.1.0.view", @"/Views/Shared/_MenuAdmin.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_MenuAdmin.cshtml", typeof(AspNetCore.Views_Shared__MenuAdmin))]
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
#line 1 "D:\DotNetCore\Karaoke\Karaoke\Views\_ViewImports.cshtml"
using Karaoke;

#line default
#line hidden
#line 2 "D:\DotNetCore\Karaoke\Karaoke\Views\_ViewImports.cshtml"
using Karaoke.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b06d49fea46f16f1153e84e290e8a6fb301eb516", @"/Views/Shared/_MenuAdmin.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c1ab61045fb0d7bd019992577e3dfbb515d76c3d", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__MenuAdmin : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("sidebar-search  "), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("page_general_search_3.html"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(0, 1924, true);
            WriteLiteral(@"<div class=""page-sidebar navbar-collapse collapse"">
    <!-- BEGIN SIDEBAR MENU -->
    <!-- DOC: Apply ""page-sidebar-menu-light"" class right after ""page-sidebar-menu"" to enable light sidebar menu style(without borders) -->
    <!-- DOC: Apply ""page-sidebar-menu-hover-submenu"" class right after ""page-sidebar-menu"" to enable hoverable(hover vs accordion) sub menu mode -->
    <!-- DOC: Apply ""page-sidebar-menu-closed"" class right after ""page-sidebar-menu"" to collapse(""page-sidebar-closed"" class must be applied to the body element) the sidebar sub menu mode -->
    <!-- DOC: Set data-auto-scroll=""false"" to disable the sidebar from auto scrolling/focusing -->
    <!-- DOC: Set data-keep-expand=""true"" to keep the submenues expanded -->
    <!-- DOC: Set data-auto-speed=""200"" to adjust the sub menu slide up/down speed -->
    <ul class=""page-sidebar-menu  page-header-fixed "" data-keep-expanded=""false"" data-auto-scroll=""true"" data-slide-speed=""200"" style=""padding-top: 20px"">
        <!-- DOC: To remove the");
            WriteLiteral(@" sidebar toggler from the sidebar you just need to completely remove the below ""sidebar-toggler-wrapper"" LI element -->
        <li class=""sidebar-toggler-wrapper hide"">
            <!-- BEGIN SIDEBAR TOGGLER BUTTON -->
            <div class=""sidebar-toggler"">
                <span></span>
            </div>
            <!-- END SIDEBAR TOGGLER BUTTON -->
        </li>
        <!-- DOC: To remove the search box from the sidebar you just need to completely remove the below ""sidebar-search-wrapper"" LI element -->
        <li class=""sidebar-search-wrapper"">
            <!-- BEGIN RESPONSIVE QUICK SEARCH FORM -->
            <!-- DOC: Apply ""sidebar-search-bordered"" class the below search form to have bordered search box -->
            <!-- DOC: Apply ""sidebar-search-bordered sidebar-search-solid"" class the below search form to have bordered & solid search box -->
            ");
            EndContext();
            BeginContext(1924, 620, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f7c20df3b91e4655929d0bb200aeef87", async() => {
                BeginContext(2005, 532, true);
                WriteLiteral(@"
                <a href=""javascript:;"" class=""remove"">
                    <i class=""icon-close""></i>
                </a>
                <div class=""input-group"">
                    <input type=""text"" class=""form-control"" placeholder=""Search..."">
                    <span class=""input-group-btn"">
                        <a href=""javascript:;"" class=""btn submit"">
                            <i class=""icon-magnifier""></i>
                        </a>
                    </span>
                </div>
            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2544, 1042, true);
            WriteLiteral(@"
            <!-- END RESPONSIVE QUICK SEARCH FORM -->
        </li>
        <li class=""heading"">
            <h3 class=""uppercase"">Features</h3>
        </li>

        <li class=""nav-item  "">
            <a href=""/admin/config"" class=""nav-link"">
                <i class=""fa fa-cog""></i>
                <span class=""title"">Cấu Hình</span>
                <span class=""arrow""></span>
            </a>
        </li>
        <li class=""nav-item  "">
            <a href=""/admin/contact"" class=""nav-link"">
                <i class=""fa fa-comment-o""></i>
                <span class=""title"">Liên Hệ</span>
                <span class=""arrow""></span>
            </a>
        </li>
        <li class=""nav-item  "">
            <a href=""/admin/new"" class=""nav-link"">
                <i class=""icon-graph""></i>
                <span class=""title"">Tin Tức</span>
                <span class=""arrow""></span>
            </a>
        </li>

    </ul>
    <!-- END SIDEBAR MENU -->
    <!-- END SIDEBAR ME");
            WriteLiteral("NU -->\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591

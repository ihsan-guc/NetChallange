#pragma checksum "C:\Users\EysanGuc\source\repos\NetChallange\NetChallange.Web\Views\Address\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "212ba9a67d1132f4c128a1b03d5755e9b7985fc3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Address_Edit), @"mvc.1.0.view", @"/Views/Address/Edit.cshtml")]
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
#line 1 "C:\Users\EysanGuc\source\repos\NetChallange\NetChallange.Web\Views\_ViewImports.cshtml"
using NetChallange.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\EysanGuc\source\repos\NetChallange\NetChallange.Web\Views\_ViewImports.cshtml"
using NetChallange.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"212ba9a67d1132f4c128a1b03d5755e9b7985fc3", @"/Views/Address/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"950f21df7e097808b7380d843dfff6b385671d97", @"/Views/_ViewImports.cshtml")]
    public class Views_Address_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NetChallange.Web.Models.AddressViewModel.AddressCEViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\EysanGuc\source\repos\NetChallange\NetChallange.Web\Views\Address\Edit.cshtml"
  
    ViewBag.Title = "Address Güncelle";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 6 "C:\Users\EysanGuc\source\repos\NetChallange\NetChallange.Web\Views\Address\Edit.cshtml"
 using (Html.BeginForm("EditConfirmed", "Address", FormMethod.Post, new { enctype = "multipart/form-data" }))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\EysanGuc\source\repos\NetChallange\NetChallange.Web\Views\Address\Edit.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"form-horizontal\">\r\n        ");
#nullable restore
#line 11 "C:\Users\EysanGuc\source\repos\NetChallange\NetChallange.Web\Views\Address\Edit.cshtml"
   Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 12 "C:\Users\EysanGuc\source\repos\NetChallange\NetChallange.Web\Views\Address\Edit.cshtml"
   Write(Html.HiddenFor(p => p.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 13 "C:\Users\EysanGuc\source\repos\NetChallange\NetChallange.Web\Views\Address\Edit.cshtml"
   Write(await Html.PartialAsync("_CreateEdit"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 15 "C:\Users\EysanGuc\source\repos\NetChallange\NetChallange.Web\Views\Address\Edit.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NetChallange.Web.Models.AddressViewModel.AddressCEViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591

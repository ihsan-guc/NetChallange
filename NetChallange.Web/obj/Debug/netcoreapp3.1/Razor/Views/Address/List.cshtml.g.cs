#pragma checksum "C:\Users\EysanGuc\source\repos\NetChallange\NetChallange.Web\Views\Address\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3dac484384d769d7e9d6b81c99ea1698a41d3bdd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Address_List), @"mvc.1.0.view", @"/Views/Address/List.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3dac484384d769d7e9d6b81c99ea1698a41d3bdd", @"/Views/Address/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"950f21df7e097808b7380d843dfff6b385671d97", @"/Views/_ViewImports.cshtml")]
    public class Views_Address_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NetChallange.Web.Models.AddressViewModel.AddressHomeViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\EysanGuc\source\repos\NetChallange\NetChallange.Web\Views\Address\List.cshtml"
 if (Model.PagedList.Count() > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <table class=""table table-striped table-hover"">
        <thead>
            <tr>
                <th></th>
                <th>Ülke</th>
                <th>Şehir</th>
                <th>Sokak</th>
                <th>Sokak Adı</th>
                <th>Bina Numarası</th>
                <th>Ülke Kodu</th>
            </tr>
        </thead>
");
#nullable restore
#line 17 "C:\Users\EysanGuc\source\repos\NetChallange\NetChallange.Web\Views\Address\List.cshtml"
         foreach (var item in Model.PagedList)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    <div class=\"input-group-prepend\">\r\n                        <a class=\"btn btn-outline-secondary btn-sm\" title=\"Detay\"");
            BeginWriteAttribute("href", "\r\n                           href=\"", 704, "\"", 794, 1);
#nullable restore
#line 23 "C:\Users\EysanGuc\source\repos\NetChallange\NetChallange.Web\Views\Address\List.cshtml"
WriteAttributeValue("", 739, Url.Action("Details", "Address", new { id = item.Id }), 739, 55, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                            <i class=""fa fa-eye""></i>
                        </a>
                        <button type=""button"" class=""btn btn-outline-secondary dropdown-toggle dropdown-toggle-split btn-sm"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                            <span class=""sr-only"">Toggle Dropdown</span>
                        </button>
                        <div class=""dropdown-menu"">
                            <a class=""dropdown-item""");
            BeginWriteAttribute("href", " href=\"", 1290, "\"", 1349, 1);
#nullable restore
#line 30 "C:\Users\EysanGuc\source\repos\NetChallange\NetChallange.Web\Views\Address\List.cshtml"
WriteAttributeValue("", 1297, Url.Action("Edit", "Address", new { id = item.Id }), 1297, 52, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Güncelleme</a>\r\n                            <a class=\"dropdown-item\"");
            BeginWriteAttribute("href", " href=\"", 1419, "\"", 1487, 1);
#nullable restore
#line 31 "C:\Users\EysanGuc\source\repos\NetChallange\NetChallange.Web\Views\Address\List.cshtml"
WriteAttributeValue("", 1426, Url.Action("AddressDelete", "Address", new { id = item.Id }), 1426, 61, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Sil</a>\r\n                        </div>\r\n                    </div>\r\n                </td>\r\n                <td>");
#nullable restore
#line 35 "C:\Users\EysanGuc\source\repos\NetChallange\NetChallange.Web\Views\Address\List.cshtml"
               Write(Html.DisplayFor(modelItem => item.Country));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 36 "C:\Users\EysanGuc\source\repos\NetChallange\NetChallange.Web\Views\Address\List.cshtml"
               Write(Html.DisplayFor(modelItem => item.City));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 37 "C:\Users\EysanGuc\source\repos\NetChallange\NetChallange.Web\Views\Address\List.cshtml"
               Write(Html.DisplayFor(modelItem => item.Street));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 38 "C:\Users\EysanGuc\source\repos\NetChallange\NetChallange.Web\Views\Address\List.cshtml"
               Write(Html.DisplayFor(modelItem => item.StreetName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 39 "C:\Users\EysanGuc\source\repos\NetChallange\NetChallange.Web\Views\Address\List.cshtml"
               Write(Html.DisplayFor(modelItem => item.BuildingNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 40 "C:\Users\EysanGuc\source\repos\NetChallange\NetChallange.Web\Views\Address\List.cshtml"
               Write(Html.DisplayFor(modelItem => item.CountyCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 42 "C:\Users\EysanGuc\source\repos\NetChallange\NetChallange.Web\Views\Address\List.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n");
#nullable restore
#line 44 "C:\Users\EysanGuc\source\repos\NetChallange\NetChallange.Web\Views\Address\List.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"card-body\">\r\n        ");
#nullable restore
#line 48 "C:\Users\EysanGuc\source\repos\NetChallange\NetChallange.Web\Views\Address\List.cshtml"
   Write(await Html.PartialAsync("ErrorList", "Address Yok!"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 50 "C:\Users\EysanGuc\source\repos\NetChallange\NetChallange.Web\Views\Address\List.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NetChallange.Web.Models.AddressViewModel.AddressHomeViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591

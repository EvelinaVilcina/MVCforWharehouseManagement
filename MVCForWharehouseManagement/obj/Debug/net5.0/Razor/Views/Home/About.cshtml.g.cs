#pragma checksum "C:\Users\eveli\source\repos\MVCForWharehouseManagement\MVCForWharehouseManagement\Views\Home\About.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "15823b675f645683ef4a33dce37204ef34410463"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_About), @"mvc.1.0.view", @"/Views/Home/About.cshtml")]
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
#line 1 "C:\Users\eveli\source\repos\MVCForWharehouseManagement\MVCForWharehouseManagement\Views\_ViewImports.cshtml"
using MVCForWharehouseManagement;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\eveli\source\repos\MVCForWharehouseManagement\MVCForWharehouseManagement\Views\_ViewImports.cshtml"
using MVCForWharehouseManagement.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"15823b675f645683ef4a33dce37204ef34410463", @"/Views/Home/About.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e1db8b702082849e597cfd7f6549b38f917be9fc", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_About : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MVCForWharehouseManagement.Models.WharehouseManagementViewModels.OrderDateGroup>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\eveli\source\repos\MVCForWharehouseManagement\MVCForWharehouseManagement\Views\Home\About.cshtml"
  
    ViewData["Title"] = "Order Statistics";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Order statistics</h2>\r\n\r\n<table>\r\n    <tr>\r\n        <th>\r\n            Order date\r\n        </th>\r\n        <th>\r\n            Orders\r\n        </th>\r\n    </tr>\r\n\r\n");
#nullable restore
#line 19 "C:\Users\eveli\source\repos\MVCForWharehouseManagement\MVCForWharehouseManagement\Views\Home\About.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 23 "C:\Users\eveli\source\repos\MVCForWharehouseManagement\MVCForWharehouseManagement\Views\Home\About.cshtml"
           Write(Html.DisplayFor(modelItem => item.DateTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 26 "C:\Users\eveli\source\repos\MVCForWharehouseManagement\MVCForWharehouseManagement\Views\Home\About.cshtml"
           Write(item.OrderCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 29 "C:\Users\eveli\source\repos\MVCForWharehouseManagement\MVCForWharehouseManagement\Views\Home\About.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MVCForWharehouseManagement.Models.WharehouseManagementViewModels.OrderDateGroup>> Html { get; private set; }
    }
}
#pragma warning restore 1591

#pragma checksum "C:\Users\aarias\Documents\GitHub\Disk_Inventory\DiskInventory\DiskInventory\Views\Disc\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e9010a2c8accdebc03b4c04bfeb2996785317fab"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Disc_Index), @"mvc.1.0.view", @"/Views/Disc/Index.cshtml")]
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
#line 1 "C:\Users\aarias\Documents\GitHub\Disk_Inventory\DiskInventory\DiskInventory\Views\_ViewImports.cshtml"
using DiskInventory;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\aarias\Documents\GitHub\Disk_Inventory\DiskInventory\DiskInventory\Views\_ViewImports.cshtml"
using DiskInventory.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e9010a2c8accdebc03b4c04bfeb2996785317fab", @"/Views/Disc/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"71fcf1ec9a08e63548f6b2cf1328f6c42701ad4d", @"/Views/_ViewImports.cshtml")]
    public class Views_Disc_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Disc>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\aarias\Documents\GitHub\Disk_Inventory\DiskInventory\DiskInventory\Views\Disc\Index.cshtml"
  
    ViewData["Title"] = "Disc Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h2>Disc Page</h2>\r\n\r\n<table class=\"table table-bordered table-striped\">\r\n    <thead>\r\n        <tr><th>BorrowerId</th><th>Disc Name</th><th>Release Date</th><th>StatusId</th><th>Disc Type id</th><th>GenreId</th></tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 12 "C:\Users\aarias\Documents\GitHub\Disk_Inventory\DiskInventory\DiskInventory\Views\Disc\Index.cshtml"
         foreach (var disc in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 15 "C:\Users\aarias\Documents\GitHub\Disk_Inventory\DiskInventory\DiskInventory\Views\Disc\Index.cshtml"
               Write(disc.DiscId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 16 "C:\Users\aarias\Documents\GitHub\Disk_Inventory\DiskInventory\DiskInventory\Views\Disc\Index.cshtml"
               Write(disc.DiscName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 17 "C:\Users\aarias\Documents\GitHub\Disk_Inventory\DiskInventory\DiskInventory\Views\Disc\Index.cshtml"
               Write(disc.ReleaseDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 18 "C:\Users\aarias\Documents\GitHub\Disk_Inventory\DiskInventory\DiskInventory\Views\Disc\Index.cshtml"
               Write(disc.StatusId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 19 "C:\Users\aarias\Documents\GitHub\Disk_Inventory\DiskInventory\DiskInventory\Views\Disc\Index.cshtml"
               Write(disc.DiscTypeId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 20 "C:\Users\aarias\Documents\GitHub\Disk_Inventory\DiskInventory\DiskInventory\Views\Disc\Index.cshtml"
               Write(disc.GenreId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 22 "C:\Users\aarias\Documents\GitHub\Disk_Inventory\DiskInventory\DiskInventory\Views\Disc\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Disc>> Html { get; private set; }
    }
}
#pragma warning restore 1591

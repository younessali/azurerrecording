#pragma checksum "/Users/aliyounes/Projects/pocblobStorage/pocblobStorage/Views/Home/ShowAllBlobs.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d609f64f37e4a6768d8be16584063f76646b2bf6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ShowAllBlobs), @"mvc.1.0.view", @"/Views/Home/ShowAllBlobs.cshtml")]
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
#line 1 "/Users/aliyounes/Projects/pocblobStorage/pocblobStorage/Views/_ViewImports.cshtml"
using pocblobStorage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/aliyounes/Projects/pocblobStorage/pocblobStorage/Views/_ViewImports.cshtml"
using pocblobStorage.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d609f64f37e4a6768d8be16584063f76646b2bf6", @"/Views/Home/ShowAllBlobs.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5257b224f5dd647d4b27a1627d971e86d6ec572c", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ShowAllBlobs : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<FileData>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "/Users/aliyounes/Projects/pocblobStorage/pocblobStorage/Views/Home/ShowAllBlobs.cshtml"
  
    ViewData["Title"] = "ShowAllBlobs";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>ShowAllBlobs</h1>
<table class=""table table-bordered"">
    <thead>
        <tr>
            <th>FileName</th>
            <th>FileSize</th>
            <th>ModifiedOn</th>
            <th>Play Video</th>
            <th>Download</th>
            <th>Delete</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 19 "/Users/aliyounes/Projects/pocblobStorage/pocblobStorage/Views/Home/ShowAllBlobs.cshtml"
         foreach (var data in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\n            <td>");
#nullable restore
#line 22 "/Users/aliyounes/Projects/pocblobStorage/pocblobStorage/Views/Home/ShowAllBlobs.cshtml"
           Write(data.FileName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td>");
#nullable restore
#line 23 "/Users/aliyounes/Projects/pocblobStorage/pocblobStorage/Views/Home/ShowAllBlobs.cshtml"
           Write(data.FileSize);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td>");
#nullable restore
#line 24 "/Users/aliyounes/Projects/pocblobStorage/pocblobStorage/Views/Home/ShowAllBlobs.cshtml"
           Write(data.ModifiedOn);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td> <a");
            BeginWriteAttribute("href", " href=\"", 562, "\"", 604, 2);
            WriteAttributeValue("", 569, "/Home/Video?blobName=", 569, 21, true);
#nullable restore
#line 25 "/Users/aliyounes/Projects/pocblobStorage/pocblobStorage/Views/Home/ShowAllBlobs.cshtml"
WriteAttributeValue("", 590, data.FileName, 590, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Stream Video</a> </td>\n            <td> <a");
            BeginWriteAttribute("href", " href=\"", 648, "\"", 693, 2);
            WriteAttributeValue("", 655, "/Home/Download?blobName=", 655, 24, true);
#nullable restore
#line 26 "/Users/aliyounes/Projects/pocblobStorage/pocblobStorage/Views/Home/ShowAllBlobs.cshtml"
WriteAttributeValue("", 679, data.FileName, 679, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Download</a> </td>\n            <td> <a");
            BeginWriteAttribute("href", " href=\"", 733, "\"", 776, 2);
            WriteAttributeValue("", 740, "/Home/Delete?blobName=", 740, 22, true);
#nullable restore
#line 27 "/Users/aliyounes/Projects/pocblobStorage/pocblobStorage/Views/Home/ShowAllBlobs.cshtml"
WriteAttributeValue("", 762, data.FileName, 762, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Delete</a> </td>\n        </tr>\n");
#nullable restore
#line 29 "/Users/aliyounes/Projects/pocblobStorage/pocblobStorage/Views/Home/ShowAllBlobs.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<FileData>> Html { get; private set; }
    }
}
#pragma warning restore 1591

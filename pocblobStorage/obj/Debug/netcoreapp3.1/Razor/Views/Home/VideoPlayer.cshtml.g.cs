#pragma checksum "/Users/aliyounes/Projects/pocblobStorage/pocblobStorage/Views/Home/VideoPlayer.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e758600a8e0611a76f764d1af65f1fe93616f872"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_VideoPlayer), @"mvc.1.0.view", @"/Views/Home/VideoPlayer.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e758600a8e0611a76f764d1af65f1fe93616f872", @"/Views/Home/VideoPlayer.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5257b224f5dd647d4b27a1627d971e86d6ec572c", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_VideoPlayer : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "/Users/aliyounes/Projects/pocblobStorage/pocblobStorage/Views/Home/VideoPlayer.cshtml"
  
    ViewData["Title"] = "Video Player";
    var videoUrl = (string)ViewData["Video"];

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n<video width=\"576\" height=\"320\" controls id=\"video\">\n    <source");
            BeginWriteAttribute("src", " src=", 157, "", 171, 1);
#nullable restore
#line 8 "/Users/aliyounes/Projects/pocblobStorage/pocblobStorage/Views/Home/VideoPlayer.cshtml"
WriteAttributeValue("", 162, videoUrl, 162, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" type=\"video/mp4\" />\n</video>");
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

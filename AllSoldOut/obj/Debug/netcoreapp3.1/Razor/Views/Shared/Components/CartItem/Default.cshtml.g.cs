#pragma checksum "C:\Users\Admin\source\repos\AllSoldOut\AllSoldOut\Views\Shared\Components\CartItem\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e23e00890556fb75d5c7681ec62d267f456636dc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_CartItem_Default), @"mvc.1.0.view", @"/Views/Shared/Components/CartItem/Default.cshtml")]
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
#line 1 "C:\Users\Admin\source\repos\AllSoldOut\AllSoldOut\Views\_ViewImports.cshtml"
using AllSoldOut;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\source\repos\AllSoldOut\AllSoldOut\Views\_ViewImports.cshtml"
using AllSoldOut.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e23e00890556fb75d5c7681ec62d267f456636dc", @"/Views/Shared/Components/CartItem/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3549e73e91aa57a836bf4369d852ea612c511087", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_CartItem_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<AllSoldOut.Models.Cart>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Checkout", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n    <div class=\"cart-list\">\r\n");
#nullable restore
#line 4 "C:\Users\Admin\source\repos\AllSoldOut\AllSoldOut\Views\Shared\Components\CartItem\Default.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"product-widget\">\r\n                <div class=\"product-img\">\r\n");
#nullable restore
#line 8 "C:\Users\Admin\source\repos\AllSoldOut\AllSoldOut\Views\Shared\Components\CartItem\Default.cshtml"
                      
                        string path = Url.Content("~/Files/" + (item.productImageName).ToString() + ".png");
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <img");
            BeginWriteAttribute("src", " src=\"", 390, "\"", 401, 1);
#nullable restore
#line 11 "C:\Users\Admin\source\repos\AllSoldOut\AllSoldOut\Views\Shared\Components\CartItem\Default.cshtml"
WriteAttributeValue("", 396, path, 396, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 402, "\"", 408, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                </div>\r\n                <div class=\"product-body\">\r\n                    <h3 class=\"product-name\"><a href=\"#\">");
#nullable restore
#line 14 "C:\Users\Admin\source\repos\AllSoldOut\AllSoldOut\Views\Shared\Components\CartItem\Default.cshtml"
                                                    Write(Html.DisplayFor(modelItem => item.productName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></h3>\r\n                    <h4 class=\"product-price\"><span class=\"qty\">");
#nullable restore
#line 15 "C:\Users\Admin\source\repos\AllSoldOut\AllSoldOut\Views\Shared\Components\CartItem\Default.cshtml"
                                                           Write(Html.DisplayFor(modelItem => item.quantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("x</span>$");
#nullable restore
#line 15 "C:\Users\Admin\source\repos\AllSoldOut\AllSoldOut\Views\Shared\Components\CartItem\Default.cshtml"
                                                                                                                Write(Html.DisplayFor(modelItem => item.total));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                </div>\r\n                <button class=\"delete\"><i class=\"fa fa-close\"></i></button>\r\n            </div>\r\n");
#nullable restore
#line 19 "C:\Users\Admin\source\repos\AllSoldOut\AllSoldOut\Views\Shared\Components\CartItem\Default.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    <div class=\"cart-summary\">\r\n        <small>");
#nullable restore
#line 22 "C:\Users\Admin\source\repos\AllSoldOut\AllSoldOut\Views\Shared\Components\CartItem\Default.cshtml"
          Write(ViewBag.countCart);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Item(s) selected</small>\r\n        <h5>SUBTOTAL: $");
#nullable restore
#line 23 "C:\Users\Admin\source\repos\AllSoldOut\AllSoldOut\Views\Shared\Components\CartItem\Default.cshtml"
                  Write(ViewBag.sumOfTotal);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n    </div>\r\n    <div class=\"cart-btns\">\r\n        <a href=\"#\">View Cart</a>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e23e00890556fb75d5c7681ec62d267f456636dc7378", async() => {
                WriteLiteral("Checkout  <i class=\"fa fa-arrow-circle-right\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<AllSoldOut.Models.Cart>> Html { get; private set; }
    }
}
#pragma warning restore 1591

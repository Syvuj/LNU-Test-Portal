#pragma checksum "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Account\ConfirmEmail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b5fe812b3d212359b0b104f5bfd63526f292f0b6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_ConfirmEmail), @"mvc.1.0.view", @"/Views/Account/ConfirmEmail.cshtml")]
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
#line 1 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\_ViewImports.cshtml"
using LNU_Test_Portal;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b5fe812b3d212359b0b104f5bfd63526f292f0b6", @"/Views/Account/ConfirmEmail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eba1fa4f8f53d65da6d08c58883bd2d4d29ffa7b", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_ConfirmEmail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Account\ConfirmEmail.cshtml"
  
    ViewData["Title"] = "Confirm Email";
    Layout = "_Layout-3";
    string LinkConfirm = ViewData["EmailConfirmLink"].ToString(); 

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""mask d-flex align-items-center h-100 gradient-custom-3"">
    <div class=""container h-100"">
        <div class=""row d-flex justify-content-center align-items-center h-100"">
            <div class=""col-12 col-md-9 col-lg-7 col-xl-6"">
                <div class=""LogInForm card""  style=""border-radius: 15px;"">
                    <div class=""card-body p-5"">
                        <h2>
                     ");
#nullable restore
#line 15 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Account\ConfirmEmail.cshtml"
                Write(ViewBag.ErrorTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                       </h2>\r\n                       <h2>\r\n                     ");
#nullable restore
#line 18 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Account\ConfirmEmail.cshtml"
                Write(ViewBag.ErrorMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                       </h2>\r\n              \r\n                    </div>\r\n                    <div class=\"d-flex justify-content-center form-outline mb-4\">\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 867, "\"", 886, 1);
#nullable restore
#line 23 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Account\ConfirmEmail.cshtml"
WriteAttributeValue("", 874, LinkConfirm, 874, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"LogInButton btn btn-primary\" style=\"background-color: #79819e; color: #ffffff;margin-top:10px\"> Confirm Your Email</a>\r\n            </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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

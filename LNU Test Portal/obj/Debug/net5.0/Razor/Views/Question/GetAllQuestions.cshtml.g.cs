#pragma checksum "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\GetAllQuestions.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5dab6c89970fdd04f10a621d41d66f11726a0f04"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Question_GetAllQuestions), @"mvc.1.0.view", @"/Views/Question/GetAllQuestions.cshtml")]
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
#nullable restore
#line 2 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\GetAllQuestions.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\GetAllQuestions.cshtml"
using Data_Access_Layer.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5dab6c89970fdd04f10a621d41d66f11726a0f04", @"/Views/Question/GetAllQuestions.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eba1fa4f8f53d65da6d08c58883bd2d4d29ffa7b", @"/Views/_ViewImports.cshtml")]
    public class Views_Question_GetAllQuestions : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Data_Access_Layer.Entities.Question>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("background: #79819E;font-family: \'Montserrat\', sans-serif;font-size: 24px;font-weight: 700;color: #FFFFFF;padding: 5px; margin:20px; margin-left:20px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Question", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("background: #79819E;font-family: \'Montserrat\', sans-serif;font-size: 24px;font-weight: 700;color: #FFFFFF;padding: 5px;margin:20px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Test", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "GetAllTests", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("background: #79819E;font-family: \'Montserrat\', sans-serif;font-size: 24px;font-weight: 700;color: #FFFFFF;padding: 5px; margin:20px; margin-left:0px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 5 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\GetAllQuestions.cshtml"
  
	ViewData["Title"] = "Manage Test";
    Layout = "_Layout-2";
	Test CurTest = (Test)TempData["CurrentTest"];
	int SumScores = 0;
	

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\GetAllQuestions.cshtml"
     foreach(var ques in Model)
	{
		SumScores += ques.Scores;
	}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"manage course content\">\r\n");
#nullable restore
#line 20 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\GetAllQuestions.cshtml"
     if (signInMahager.IsSignedIn(User) && User.IsInRole("Teacher"))
    {
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    \r\n\r\n       \r\n");
#nullable restore
#line 26 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\GetAllQuestions.cshtml"
     if (Model.Count() !=0)
	{
		

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t<div class=\"questionDetails flex-column justify-content-between\">\r\n\t<div class=\"test_container_text \">\r\n\t\t<h3>");
#nullable restore
#line 31 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\GetAllQuestions.cshtml"
       Write(CurTest.name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n\t\t<h3>Scores:");
#nullable restore
#line 32 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\GetAllQuestions.cshtml"
              Write(SumScores);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n\t</div>\r\n\r\n");
#nullable restore
#line 35 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\GetAllQuestions.cshtml"
          
			int counter = 0;

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\GetAllQuestions.cshtml"
         foreach(var ques in Model)
		{
			counter++;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"			<div class=""flex-column justify-content-between"" style=""width: 80%; background: #FFFFFF;margin: auto;padding-top: 25px;"">
				<div class=""flex-column justify-content-between"" style=""width: 95%;background: #FFFFFF;border: 1px solid #000000;border-radius: 5px; padding: 20px;margin: auto; "">
					<h3 class=""question_number"">Question №");
#nullable restore
#line 42 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\GetAllQuestions.cshtml"
                                                     Write(counter);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n\t\t\t\t\t<h3 class=\"question_number\" style=\"text-decoration:none;\">Scores:");
#nullable restore
#line 43 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\GetAllQuestions.cshtml"
                                                                                Write(ques.Scores);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n\t\t\t\t\t<div class=\"flex-column justify-content-between\" style=\"background-color:#f3f3f3;margin: auto;\">\r\n\t\t\t\t\t\t<p style=\"font-family: \'Montserrat\', sans-serif; font-weight: 400;color: #000000;font-size: 24px;padding:13px;\">");
#nullable restore
#line 45 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\GetAllQuestions.cshtml"
                                                                                                                                   Write(ques.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
					</div >
					<h3 class=""answers_test"">Answers (separated by commas):</h3>
					<div class=""flex-column justify-content-between"" style=""background-color:#f3f3f3;"">
						<p style=""font-family: 'Montserrat', sans-serif; font-weight: 400;color: #000000;font-size: 24px;padding:13px;"">");
#nullable restore
#line 49 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\GetAllQuestions.cshtml"
                                                                                                                                   Write(ques.Options);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\t\t\t\t\t</div >\r\n\t\t\t\t\t<h3 class=\"answers_test\">Correct answer:</h3>\r\n\t\t\t\t\t<div class=\"answers\">\r\n\t\t\t\t\t\t<p>");
#nullable restore
#line 53 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\GetAllQuestions.cshtml"
                      Write(ques.Key);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\t\t\t\t\t</div>\r\n\t\t\t\t\t<div class=\"d-flex justify-content-start\" style=\"margin-top:20px;\">\r\n\t\t\t\t\t\t<a");
            BeginWriteAttribute("href", " href=\"", 2026, "\"", 2068, 4);
            WriteAttributeValue("", 2033, "/Question/Edit/", 2033, 15, true);
#nullable restore
#line 56 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\GetAllQuestions.cshtml"
WriteAttributeValue("", 2048, CurTest.id, 2048, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2059, "/", 2059, 1, true);
#nullable restore
#line 56 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\GetAllQuestions.cshtml"
WriteAttributeValue("", 2060, ques.id, 2060, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn\" role=\"button\" style=\"background: #79819E;font-family: \'Montserrat\', sans-serif;font-size: 24px;font-weight: 700;color: #FFFFFF;padding: 5px; margin-right:20px;\">Edit</a>\r\n\t\t\t\t\t\t<a");
            BeginWriteAttribute("href", " href=\"", 2261, "\"", 2305, 4);
            WriteAttributeValue("", 2268, "/Question/Delete/", 2268, 17, true);
#nullable restore
#line 57 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\GetAllQuestions.cshtml"
WriteAttributeValue("", 2285, CurTest.id, 2285, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2296, "/", 2296, 1, true);
#nullable restore
#line 57 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\GetAllQuestions.cshtml"
WriteAttributeValue("", 2297, ques.id, 2297, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn\" role=\"button\" style=\"background: #79819E;font-family: \'Montserrat\', sans-serif;font-size: 24px;font-weight: 700;color: #FFFFFF;padding: 5px;\">Delete</a>\r\n\t\t\t\t\t</div>\t\t\t\r\n\t\t</div>\r\n\t</div>\r\n");
#nullable restore
#line 61 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\GetAllQuestions.cshtml"
		}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t<div class=\"flex-column justify-content-between\" style=\"width: 80%; background: #FFFFFF;margin: auto;padding-top: 25px;\">\r\n<div class=\"d-flex justify-content-start\" style=\"margin-top:20px;\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5dab6c89970fdd04f10a621d41d66f11726a0f0414288", async() => {
                WriteLiteral("Add Question");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 64 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\GetAllQuestions.cshtml"
                                                                                                                                                                                                                                                    WriteLiteral(CurTest.id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\t\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5dab6c89970fdd04f10a621d41d66f11726a0f0417126", async() => {
                WriteLiteral("Back");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n\r\n</div>\r\n\t\t\r\n\t\r\n</div>\r\n");
#nullable restore
#line 72 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\GetAllQuestions.cshtml"
	}
	else
	{

		

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t<h3 style=\"color:black;\">");
#nullable restore
#line 77 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\GetAllQuestions.cshtml"
                            Write(CurTest.name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n");
            WriteLiteral("\t\t<div class=\"d-flex justify-content-start\" style=\"margin-top:20px;\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5dab6c89970fdd04f10a621d41d66f11726a0f0419430", async() => {
                WriteLiteral("Add Question");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 80 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\GetAllQuestions.cshtml"
                                                                                                                                                                                                                                                   WriteLiteral(CurTest.id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\t\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5dab6c89970fdd04f10a621d41d66f11726a0f0422267", async() => {
                WriteLiteral("Back");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 83 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\GetAllQuestions.cshtml"
	}

#line default
#line hidden
#nullable disable
            WriteLiteral("            \r\n    \r\n </div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<ApplicationUser> signInMahager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Data_Access_Layer.Entities.Question>> Html { get; private set; }
    }
}
#pragma warning restore 1591
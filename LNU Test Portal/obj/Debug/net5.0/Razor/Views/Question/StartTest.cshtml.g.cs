#pragma checksum "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\StartTest.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e258d9835066c16d4e1cb81656f14f2b4ef8a076"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Question_StartTest), @"mvc.1.0.view", @"/Views/Question/StartTest.cshtml")]
namespace AspNetCore
{
    #line hidden
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
#line 2 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\StartTest.cshtml"
using System;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\StartTest.cshtml"
using Data_Access_Layer.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\StartTest.cshtml"
using LNU_Test_Portal.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e258d9835066c16d4e1cb81656f14f2b4ef8a076", @"/Views/Question/StartTest.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eba1fa4f8f53d65da6d08c58883bd2d4d29ffa7b", @"/Views/_ViewImports.cshtml")]
    public class Views_Question_StartTest : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<QaAnViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-asp-controller", new global::Microsoft.AspNetCore.Html.HtmlString("Question"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "StartTest", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\StartTest.cshtml"
  
	ViewData["Title"] = "Start Test";
    Layout = "_Layout-2";
	Test CurTest = (Test)TempData["CurrentTest"];
	int SumScores = 0;
	

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\StartTest.cshtml"
     foreach(var ques in Model)
	{
		SumScores += ques.Scores;
	}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n<div class=\"manage course content\">\r\n\r\n\r\n\r\n\t\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e258d9835066c16d4e1cb81656f14f2b4ef8a0765282", async() => {
                WriteLiteral("\r\n\t\t\t");
#nullable restore
#line 30 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\StartTest.cshtml"
       Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\t\t\t\r\n    \r\n");
#nullable restore
#line 33 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\StartTest.cshtml"
     if (Model.Count() !=0)
	{
		

#line default
#line hidden
#nullable disable
                WriteLiteral("\t\t<div class=\"questionDetails flex-column justify-content-between\">\r\n\t<div class=\"test_container_text \">\r\n\t\t<h3>");
#nullable restore
#line 38 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\StartTest.cshtml"
       Write(CurTest.name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h3>\r\n\t\t<h3>Available Points:");
#nullable restore
#line 39 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\StartTest.cshtml"
                        Write(SumScores);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h3>\r\n\t\r\n\t</div>\r\n");
#nullable restore
#line 42 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\StartTest.cshtml"
          
			int counter1 = 0;

#line default
#line hidden
#nullable disable
#nullable restore
#line 44 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\StartTest.cshtml"
         for(int i=0;i<Model.Count();i++)
		{
			
			

#line default
#line hidden
#nullable disable
#nullable restore
#line 47 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\StartTest.cshtml"
       Write(Html.HiddenFor(m=>Model[i].id));

#line default
#line hidden
#nullable disable
#nullable restore
#line 48 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\StartTest.cshtml"
       Write(Html.HiddenFor(m=>Model[i].Key));

#line default
#line hidden
#nullable disable
#nullable restore
#line 49 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\StartTest.cshtml"
       Write(Html.HiddenFor(m=>Model[i].TestId));

#line default
#line hidden
#nullable disable
#nullable restore
#line 50 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\StartTest.cshtml"
       Write(Html.HiddenFor(m=>Model[i].Scores));

#line default
#line hidden
#nullable disable
#nullable restore
#line 50 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\StartTest.cshtml"
                                               
			
			counter1++;

#line default
#line hidden
#nullable disable
                WriteLiteral(@"			<div class=""flex-column justify-content-between"" style=""width: 80%; background: #FFFFFF;margin: auto;padding-top: 25px;"">
				<div class=""flex-column justify-content-between"" style=""width: 95%;background: #FFFFFF;border: 1px solid #000000;border-radius: 5px; padding: 20px;margin: auto; "">
				<h3 class=""question_number"" style=""text-decoration:none;"">Question №");
#nullable restore
#line 55 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\StartTest.cshtml"
                                                                               Write(counter1);

#line default
#line hidden
#nullable disable
                WriteLiteral(" (");
#nullable restore
#line 55 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\StartTest.cshtml"
                                                                                          Write(Model[i].Scores);

#line default
#line hidden
#nullable disable
                WriteLiteral(" points)</h3>\r\n\t\t        <h3 class=\"question_number\" style=\"text-decoration:none;font-weight: normal;\">");
#nullable restore
#line 56 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\StartTest.cshtml"
                                                                                         Write(Model[i].Title);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h3>\r\n\r\n\t\t\t\t\t\r\n\t\t\t\t\t<div class=\"flex-column justify-content-between\">\r\n\r\n\r\n");
#nullable restore
#line 62 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\StartTest.cshtml"
                          
							List<string> optionSt = Model[i].Options.Split(',').ToList();
							string ttt = counter1.ToString(); 
						

#line default
#line hidden
#nullable disable
                WriteLiteral("\t\t\t\t\t\r\n\r\n");
#nullable restore
#line 68 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\StartTest.cshtml"
                                 for(int j=0;j<optionSt.Count();j++)
								{


									

#line default
#line hidden
#nullable disable
#nullable restore
#line 72 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\StartTest.cshtml"
                               Write(Html.RadioButtonFor(p=>Model[i].NewStudentAnswer,optionSt[j], new {style="height:18px;width:18px; margin:4px;vertical-align: middle;"}));

#line default
#line hidden
#nullable disable
#nullable restore
#line 72 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\StartTest.cshtml"
                                                                                                                                                                        Write(Html.LabelFor(p=>Model[i].NewStudentAnswer,optionSt[j],new {style="font-size:18px;margin-left:4px;"}));

#line default
#line hidden
#nullable disable
                WriteLiteral("<br>\r\n");
#nullable restore
#line 73 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\StartTest.cshtml"
						}

#line default
#line hidden
#nullable disable
                WriteLiteral("\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t</div >\r\n\t\t\t\t\t\t\t\t\r\n\t\t</div>\r\n\t</div>\r\n");
#nullable restore
#line 79 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\StartTest.cshtml"
		}

#line default
#line hidden
#nullable disable
                WriteLiteral("\t\t<div class=\"flex-column justify-content-between\" style=\"width: 80%; background: #FFFFFF;margin: auto;padding-top: 25px;\">\r\n<div class=\"d-flex justify-content-start\" style=\"margin-top:20px;\">\r\n");
                WriteLiteral(@"		<input type=""submit"" class=""btn"" role=""button"" style=""background: #79819E;font-family: 'Montserrat', sans-serif;font-size: 24px;font-weight: 700;color: #FFFFFF;padding: 5px; margin:20px; margin-left:20px;""  value=""Finish Test"">
    </div>
</div>	
</div>
");
#nullable restore
#line 87 "D:\My Visual Studio proj\LNU Test Portal\LNU Test Portal\Views\Question\StartTest.cshtml"
	} 

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\t");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n </div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<QaAnViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591

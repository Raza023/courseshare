#pragma checksum "D:\working\Course Share\webapp\Views\Home\contactus.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "670e8db6da1abb79195168ea677bd630ecd0d228"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_contactus), @"mvc.1.0.view", @"/Views/Home/contactus.cshtml")]
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
#line 1 "D:\working\Course Share\webapp\Views\_ViewImports.cshtml"
using webapp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\working\Course Share\webapp\Views\_ViewImports.cshtml"
using webapp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"670e8db6da1abb79195168ea677bd630ecd0d228", @"/Views/Home/contactus.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2adfb2cb35d07cd7b59626653cd077330bdbd9ac", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_contactus : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("myform"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/home/contactus"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 1 "D:\working\Course Share\webapp\Views\Home\contactus.cshtml"
  
    Layout = "../Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 5 "D:\working\Course Share\webapp\Views\Home\contactus.cshtml"
  
    ViewData["Title"] = "Contact Us";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container\">\r\n    <main role=\"main\" class=\"pb-3\">\r\n        <br>\r\n        <h1 class=\"text-center\">");
#nullable restore
#line 12 "D:\working\Course Share\webapp\Views\Home\contactus.cshtml"
                           Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n        <br>\r\n        <div class=\"row\">\r\n            <div class=\"col-md-8\">\r\n                <div class=\"well well-sm\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "670e8db6da1abb79195168ea677bd630ecd0d2285061", async() => {
                WriteLiteral(@"
                        <div class=""row"">
                            <div class=""col-md-6"">
                                <div class=""form-group"">
                                    <label for=""name"">
                                        Name
                                    </label>
                                    <input type=""text"" name=""name"" class=""form-control"" id=""name"" placeholder=""Enter name"" required=""required"" />
                                </div>
                                <div class=""form-group"">
                                    <label for=""email"">
                                        Email Address
                                    </label>
                                    <div class=""input-group"">
                                        <span class=""input-group-addon"">
                                            <span class=""glyphicon glyphicon-envelope""></span>
                                        </span>
                                    ");
                WriteLiteral(@"    <input type=""email"" name=""email"" class=""form-control"" id=""email"" placeholder=""Enter email"" required=""required"" />
                                    </div>
                                </div>
                                <div class=""form-group"">
                                    <label for=""subject"">
                                        Subject
                                    </label>
                                    <input type=""text"" name=""subject"" class=""form-control"" id=""subject"" placeholder=""Enter subject"" required=""required"" />
                                </div>
                            </div>
                            <div class=""col-md-6"">
                                <div class=""form-group"">
                                    <label for=""name"">
                                        Message
                                    </label>
                                    <textarea name=""message"" id=""message"" class=""form-control"" rows=""9"" cols=""25"" re");
                WriteLiteral(@"quired=""required""
                                            placeholder=""Message""></textarea>
                                </div>
                            </div>
                            <div class=""col-md-12"">
                                <button type=""submit"" class=""btn btn-primary pull-right"" id=""btnContactUs"">
                                    Send Message
                                </button>
                            </div>
                        </div>
                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"col-md-4\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "670e8db6da1abb79195168ea677bd630ecd0d2289482", async() => {
                WriteLiteral(@"
                    <legend>
                        <svg xmlns=""http://www.w3.org/2000/svg"" width=""16"" height=""16"" fill=""currentColor"" class=""bi bi-building"" viewBox=""0 0 16 16"">
                            <path fill-rule=""evenodd"" d=""M14.763.075A.5.5 0 0 1 15 .5v15a.5.5 0 0 1-.5.5h-3a.5.5 0 0 1-.5-.5V14h-1v1.5a.5.5 0 0 1-.5.5h-9a.5.5 0 0 1-.5-.5V10a.5.5 0 0 1 .342-.474L6 7.64V4.5a.5.5 0 0 1 .276-.447l8-4a.5.5 0 0 1 .487.022zM6 8.694 1 10.36V15h5V8.694zM7 15h2v-1.5a.5.5 0 0 1 .5-.5h2a.5.5 0 0 1 .5.5V15h2V1.309l-7 3.5V15z"" />
                            <path d=""M2 11h1v1H2v-1zm2 0h1v1H4v-1zm-2 2h1v1H2v-1zm2 0h1v1H4v-1zm4-4h1v1H8V9zm2 0h1v1h-1V9zm-2 2h1v1H8v-1zm2 0h1v1h-1v-1zm2-2h1v1h-1V9zm0 2h1v1h-1v-1zM8 7h1v1H8V7zm2 0h1v1h-1V7zm2 0h1v1h-1V7zM8 5h1v1H8V5zm2 0h1v1h-1V5zm2 0h1v1h-1V5zm0-2h1v1h-1V3z"" />
                        </svg> 
                        Our office
                    </legend>
                    <address>
                        <strong>Twitter, Inc.</strong><br>
            ");
                WriteLiteral(@"            Tech Master, Academy road 05<br>
                        Lahore, Cantt area<br>
                        <abbr title=""Phone"">
                            Phone:
                        </abbr>
                        +92 324 4614345
                    </address>
                    <address>
                        <strong>Admin Name: Hassan Raza</strong><br>
                        <a href=""mailto:#"">bitf19a023@pucit.edu.pk</a>
                    </address>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n        \r\n");
#nullable restore
#line 88 "D:\working\Course Share\webapp\Views\Home\contactus.cshtml"
         if(Model != null)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 90 "D:\working\Course Share\webapp\Views\Home\contactus.cshtml"
             if(Model == "Your message has been sent.")
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <br/>\r\n                <div class=\"alert alert-success  text-center\">\r\n                    <strong>");
#nullable restore
#line 94 "D:\working\Course Share\webapp\Views\Home\contactus.cshtml"
                       Write(Model);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n                </div>\r\n");
#nullable restore
#line 96 "D:\working\Course Share\webapp\Views\Home\contactus.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <br/>\r\n                <div class=\"alert alert-danger  text-center\">\r\n                    <strong>");
#nullable restore
#line 101 "D:\working\Course Share\webapp\Views\Home\contactus.cshtml"
                       Write(Model);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n                </div>\r\n");
#nullable restore
#line 103 "D:\working\Course Share\webapp\Views\Home\contactus.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 103 "D:\working\Course Share\webapp\Views\Home\contactus.cshtml"
             
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        \r\n    </main>\r\n</div>\r\n\r\n\r\n");
            DefineSection("AjaxCall", async() => {
                WriteLiteral(@"
<script>
$(document).ready(function () {
    $(""#ChangeFormNameHere"").submit(function (e) { 
        e.preventDefault();

        $.ajax({
            type: ""POST"",
            url: ""https://jscode.unaux.com/sendemail/index.php?callback=response"",
            data: {from: ""semester1with2@gmail.com"",to: ""semester1with2@gmail.com"",subject: $(""#subject"").val(),message: $(""#message"").val()},
            dataType: ""json"",
            success: function (response) {
                console.log(response);
            },
            error: function (response) {
                console.log(response);
            }
        });
        $(this).trigger(""reset"");
    });
});
</script>
");
            }
            );
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

#pragma checksum "C:\Users\merve\source\repos\WiredExam\WiredExam\Views\Home\Exams.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fe42f2662fd0e17b0b97f4e81cf5bf74b0e65ea6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Exams), @"mvc.1.0.view", @"/Views/Home/Exams.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Exams.cshtml", typeof(AspNetCore.Views_Home_Exams))]
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
#line 1 "C:\Users\merve\source\repos\WiredExam\WiredExam\Views\_ViewImports.cshtml"
using WiredExam;

#line default
#line hidden
#line 2 "C:\Users\merve\source\repos\WiredExam\WiredExam\Views\_ViewImports.cshtml"
using WiredExam.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fe42f2662fd0e17b0b97f4e81cf5bf74b0e65ea6", @"/Views/Home/Exams.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"75bfd7d5e32fc67f58c30dd5b5a2c7e4472a8de4", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Exams : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<DataModel.QuestionsModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\merve\source\repos\WiredExam\WiredExam\Views\Home\Exams.cshtml"
  
    ViewData["Title"] = "Sınavlar";

#line default
#line hidden
            BeginContext(90, 1185, true);
            WriteLiteral(@"

    <div class=""container"">
        <div class=""row"">
            <div class=""center-box"">

                <nav class=""navbar navbar-default"">
                    <div class=""container-fluid"">
                        <!-- Brand and toggle get grouped for better mobile display -->
                        <div class=""navbar-header"">
                            <button type=""button"" class=""navbar-toggle collapsed"" data-toggle=""collapse"" data-target=""#bs-example-navbar-collapse-1"" aria-expanded=""false"">
                                <span class=""sr-only"">Toggle navigation</span>
                                <span class=""icon-bar""></span>
                                <span class=""icon-bar""></span>
                                <span class=""icon-bar""></span>
                            </button>
                            <a class=""navbar-brand"" href=""#"">EXAM</a>
                        </div>

                        <!-- Collect the nav links, forms, and other content for toggling");
            WriteLiteral(" -->\r\n                        <div class=\"collapse navbar-collapse\" id=\"bs-example-navbar-collapse-1\">\r\n                            <ul class=\"nav navbar-nav\">\r\n");
            EndContext();
#line 27 "C:\Users\merve\source\repos\WiredExam\WiredExam\Views\Home\Exams.cshtml"
                                 if (ViewBag.Statu != "2")
                                {

#line default
#line hidden
            BeginContext(1370, 42, true);
            WriteLiteral("                                    <li><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1412, "\"", 1450, 1);
#line 29 "C:\Users\merve\source\repos\WiredExam\WiredExam\Views\Home\Exams.cshtml"
WriteAttributeValue("", 1419, Url.Action("Questions","Home"), 1419, 31, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1451, 22, true);
            WriteLiteral(">Sınav Ekle</a></li>\r\n");
            EndContext();
#line 30 "C:\Users\merve\source\repos\WiredExam\WiredExam\Views\Home\Exams.cshtml"
                                }

#line default
#line hidden
            BeginContext(1508, 38, true);
            WriteLiteral("                                <li><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1546, "\"", 1580, 1);
#line 31 "C:\Users\merve\source\repos\WiredExam\WiredExam\Views\Home\Exams.cshtml"
WriteAttributeValue("", 1553, Url.Action("Exams","Home"), 1553, 27, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1581, 573, true);
            WriteLiteral(@">Sınavlar</a></li>
                            </ul>
                        </div><!-- /.navbar-collapse -->
                    </div><!-- /.container-fluid -->
                </nav>



                <div class=""panel panel-default"">
                    <!-- Default panel contents -->
                    <table class=""table"">
                        <tr>
                            <th>#</th>
                            <th>BAŞLIK</th>
                            <th>TARİH</th>
                            <th></th>
                        </tr>
");
            EndContext();
#line 48 "C:\Users\merve\source\repos\WiredExam\WiredExam\Views\Home\Exams.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
            BeginContext(2235, 72, true);
            WriteLiteral("                            <tr>\r\n                                <td><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2307, "\"", 2369, 1);
#line 51 "C:\Users\merve\source\repos\WiredExam\WiredExam\Views\Home\Exams.cshtml"
WriteAttributeValue("", 2314, Url.Action("DetailExam", "Home", new { ID = item.ID }), 2314, 55, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2370, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(2372, 7, false);
#line 51 "C:\Users\merve\source\repos\WiredExam\WiredExam\Views\Home\Exams.cshtml"
                                                                                                 Write(item.ID);

#line default
#line hidden
            EndContext();
            BeginContext(2379, 49, true);
            WriteLiteral("</a></td>\r\n                                <td><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2428, "\"", 2490, 1);
#line 52 "C:\Users\merve\source\repos\WiredExam\WiredExam\Views\Home\Exams.cshtml"
WriteAttributeValue("", 2435, Url.Action("DetailExam", "Home", new { ID = item.ID }), 2435, 55, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2491, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(2493, 10, false);
#line 52 "C:\Users\merve\source\repos\WiredExam\WiredExam\Views\Home\Exams.cshtml"
                                                                                                 Write(item.Topic);

#line default
#line hidden
            EndContext();
            BeginContext(2503, 47, true);
            WriteLiteral("</a></td>\r\n                                <td>");
            EndContext();
            BeginContext(2551, 50, false);
#line 53 "C:\Users\merve\source\repos\WiredExam\WiredExam\Views\Home\Exams.cshtml"
                               Write(String.Format("{0:dd/MM/yyyy}", item.InsertedDate));

#line default
#line hidden
            EndContext();
            BeginContext(2601, 45, true);
            WriteLiteral("</td>\r\n                                <td><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2646, "\"", 2707, 1);
#line 54 "C:\Users\merve\source\repos\WiredExam\WiredExam\Views\Home\Exams.cshtml"
WriteAttributeValue("", 2653, Url.Action("DeleteExam","Home", new { ID = item.ID }), 2653, 54, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2708, 50, true);
            WriteLiteral(">SİL</a></td>\r\n                            </tr>\r\n");
            EndContext();
#line 56 "C:\Users\merve\source\repos\WiredExam\WiredExam\Views\Home\Exams.cshtml"
                        }

#line default
#line hidden
            BeginContext(2785, 104, true);
            WriteLiteral("\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<DataModel.QuestionsModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
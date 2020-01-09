#pragma checksum "C:\Users\Gebruiker\source\repos\ASPToep\WebApplication2\Views\Shared\Razorpages\GameContainer.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "883b25d85261e24bf3904dda4e73e2cf6aa71e33"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Razorpages_GameContainer), @"mvc.1.0.view", @"/Views/Shared/Razorpages/GameContainer.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Razorpages/GameContainer.cshtml", typeof(AspNetCore.Views_Shared_Razorpages_GameContainer))]
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
#line 1 "C:\Users\Gebruiker\source\repos\ASPToep\WebApplication2\Views\_ViewImports.cshtml"
using ASPToep;

#line default
#line hidden
#line 2 "C:\Users\Gebruiker\source\repos\ASPToep\WebApplication2\Views\_ViewImports.cshtml"
using ASPToep.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"883b25d85261e24bf3904dda4e73e2cf6aa71e33", @"/Views/Shared/Razorpages/GameContainer.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a78b4b796010a5200159588bc3c1d3fe8a3d1962", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Razorpages_GameContainer : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("btn3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Game/CreateGame", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("savePlayerButton"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 241, true);
            WriteLiteral("<div class=\"Container gameContainer managementContainer\">\r\n    <div class=\"gameInformation\">\r\n        <h1> Game Overview </h1><br /><br />\r\n        <table>\r\n            <tr>\r\n                <td>Amount of Players </td>\r\n                <td> ");
            EndContext();
            BeginContext(242, 22, false);
#line 7 "C:\Users\Gebruiker\source\repos\ASPToep\WebApplication2\Views\Shared\Razorpages\GameContainer.cshtml"
                Write(Model.playerList.Count);

#line default
#line hidden
            EndContext();
            BeginContext(264, 116, true);
            WriteLiteral("</td>\r\n            </tr>\r\n\r\n            <tr>\r\n                <td>Round</td>\r\n                <td id=\"roundCounter\">");
            EndContext();
            BeginContext(381, 11, false);
#line 12 "C:\Users\Gebruiker\source\repos\ASPToep\WebApplication2\Views\Shared\Razorpages\GameContainer.cshtml"
                                 Write(Model.Round);

#line default
#line hidden
            EndContext();
            BeginContext(392, 120, true);
            WriteLiteral("</td>\r\n            </tr>\r\n\r\n            <tr>\r\n                <td>Score Limit</td>\r\n                <td id=\"scoreLimit\">");
            EndContext();
            BeginContext(513, 11, false);
#line 17 "C:\Users\Gebruiker\source\repos\ASPToep\WebApplication2\Views\Shared\Razorpages\GameContainer.cshtml"
                               Write(Model.Limit);

#line default
#line hidden
            EndContext();
            BeginContext(524, 766, true);
            WriteLiteral(@"</td>
            </tr>
        </table>
    </div>
</div>

<div class=""Container gameContainer selectionContainer"">
    <div class=""gameSelection"">
        <h1> Players </h1><br /><br />
        <div class=""Checkbox"">
            <input id=""cbx"" type=""checkbox"" />
            <label class=""cbx"" for=""cbx"">
                <div class=""flip"">
                    <div class=""front""></div>
                    <div class=""back"">
                        <svg width=""16"" height=""14"" viewBox=""0 0 16 14"">
                            <path d=""M2 8.5L6 12.5L14 1.5""></path>
                        </svg>
                    </div>
                </div>
            </label>
            <span>Jack</span>
        </div>

        <ul id=""ulpref"">
");
            EndContext();
#line 42 "C:\Users\Gebruiker\source\repos\ASPToep\WebApplication2\Views\Shared\Razorpages\GameContainer.cshtml"
             foreach (var player in Model.playerList)
            {

#line default
#line hidden
            BeginContext(1360, 15, true);
            WriteLiteral("            <li");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 1375, "\"", 1390, 1);
#line 44 "C:\Users\Gebruiker\source\repos\ASPToep\WebApplication2\Views\Shared\Razorpages\GameContainer.cshtml"
WriteAttributeValue("", 1380, player.Id, 1380, 10, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1391, 51, true);
            WriteLiteral(">\r\n                <label id=\"id\" class=\"playerId\">");
            EndContext();
            BeginContext(1443, 9, false);
#line 45 "C:\Users\Gebruiker\source\repos\ASPToep\WebApplication2\Views\Shared\Razorpages\GameContainer.cshtml"
                                           Write(player.Id);

#line default
#line hidden
            EndContext();
            BeginContext(1452, 70, true);
            WriteLiteral("</label>\r\n                <label id=\"username\" class=\"playerUsername\">");
            EndContext();
            BeginContext(1523, 15, false);
#line 46 "C:\Users\Gebruiker\source\repos\ASPToep\WebApplication2\Views\Shared\Razorpages\GameContainer.cshtml"
                                                       Write(player.Username);

#line default
#line hidden
            EndContext();
            BeginContext(1538, 66, true);
            WriteLiteral("</label>\r\n                <label id=\"knocked\" class=\"playerScore\">");
            EndContext();
            BeginContext(1605, 14, false);
#line 47 "C:\Users\Gebruiker\source\repos\ASPToep\WebApplication2\Views\Shared\Razorpages\GameContainer.cshtml"
                                                   Write(player.Knocked);

#line default
#line hidden
            EndContext();
            BeginContext(1619, 65, true);
            WriteLiteral("</label>\r\n                <label id=\"score\" class=\"playerPoints\">");
            EndContext();
            BeginContext(1685, 12, false);
#line 48 "C:\Users\Gebruiker\source\repos\ASPToep\WebApplication2\Views\Shared\Razorpages\GameContainer.cshtml"
                                                  Write(player.Score);

#line default
#line hidden
            EndContext();
            BeginContext(1697, 12, true);
            WriteLiteral("</label>\r\n\r\n");
            EndContext();
#line 50 "C:\Users\Gebruiker\source\repos\ASPToep\WebApplication2\Views\Shared\Razorpages\GameContainer.cshtml"
                 if (player.Lost)
                {

#line default
#line hidden
            BeginContext(1763, 86, true);
            WriteLiteral("                    <label id=\"lost\" value=\"1\" class=\"playerLost\">ELIMINATED</label>\r\n");
            EndContext();
#line 53 "C:\Users\Gebruiker\source\repos\ASPToep\WebApplication2\Views\Shared\Razorpages\GameContainer.cshtml"
                }
                else
                {

#line default
#line hidden
            BeginContext(1909, 69, true);
            WriteLiteral("                    <label id=\"lost\" style=\"display:none\">0</label>\r\n");
            EndContext();
#line 57 "C:\Users\Gebruiker\source\repos\ASPToep\WebApplication2\Views\Shared\Razorpages\GameContainer.cshtml"
                }

#line default
#line hidden
            BeginContext(1997, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 59 "C:\Users\Gebruiker\source\repos\ASPToep\WebApplication2\Views\Shared\Razorpages\GameContainer.cshtml"
                 if (player.Won)
                {

#line default
#line hidden
            BeginContext(2052, 80, true);
            WriteLiteral("                    <label id=\"won\" value=\"1\" class=\"playerWon\">WINNER</label>\r\n");
            EndContext();
#line 62 "C:\Users\Gebruiker\source\repos\ASPToep\WebApplication2\Views\Shared\Razorpages\GameContainer.cshtml"
                }
                else
                {

#line default
#line hidden
            BeginContext(2192, 68, true);
            WriteLiteral("                    <label id=\"won\" style=\"display:none\">0</label>\r\n");
            EndContext();
#line 66 "C:\Users\Gebruiker\source\repos\ASPToep\WebApplication2\Views\Shared\Razorpages\GameContainer.cshtml"
                }

#line default
#line hidden
            BeginContext(2279, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 68 "C:\Users\Gebruiker\source\repos\ASPToep\WebApplication2\Views\Shared\Razorpages\GameContainer.cshtml"
                 if (!player.Won && !player.Lost)
                {

#line default
#line hidden
            BeginContext(2351, 53, true);
            WriteLiteral("                    <button onclick=\"PlayerWin(this)\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2404, "\"", 2422, 1);
#line 70 "C:\Users\Gebruiker\source\repos\ASPToep\WebApplication2\Views\Shared\Razorpages\GameContainer.cshtml"
WriteAttributeValue("", 2412, player.Id, 2412, 10, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2423, 42, true);
            WriteLiteral(" class=\"playerWonButton\">Winner</button>\r\n");
            EndContext();
            BeginContext(2467, 81, true);
            WriteLiteral("                    <button onclick=\"PlayerKnock(this)\" class=\"playerKnockButton\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2548, "\"", 2566, 1);
#line 72 "C:\Users\Gebruiker\source\repos\ASPToep\WebApplication2\Views\Shared\Razorpages\GameContainer.cshtml"
WriteAttributeValue("", 2556, player.Id, 2556, 10, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2567, 17, true);
            WriteLiteral(">Knock</button>\r\n");
            EndContext();
#line 73 "C:\Users\Gebruiker\source\repos\ASPToep\WebApplication2\Views\Shared\Razorpages\GameContainer.cshtml"
                }

#line default
#line hidden
            BeginContext(2603, 45, true);
            WriteLiteral("\r\n                <hr />\r\n            </li>\r\n");
            EndContext();
#line 77 "C:\Users\Gebruiker\source\repos\ASPToep\WebApplication2\Views\Shared\Razorpages\GameContainer.cshtml"
                        
            }

#line default
#line hidden
            BeginContext(2689, 33, true);
            WriteLiteral("        </ul>\r\n    </div>\r\n\r\n    ");
            EndContext();
            BeginContext(2722, 106, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "883b25d85261e24bf3904dda4e73e2cf6aa71e3313489", async() => {
                BeginContext(2794, 25, true);
                WriteLiteral("\r\n        Stop Game\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2828, 8, true);
            WriteLiteral("\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591

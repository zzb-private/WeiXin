#pragma checksum "C:\Users\Net\Desktop\WeiXin\ZZB.Core\ZZB.WebMVC.Core\Areas\WeiXin\Views\Member\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "41d1539aacab721ac39ead7ccd64df987b77cbd2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_WeiXin_Views_Member_Index), @"mvc.1.0.view", @"/Areas/WeiXin/Views/Member/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"41d1539aacab721ac39ead7ccd64df987b77cbd2", @"/Areas/WeiXin/Views/Member/Index.cshtml")]
    public class Areas_WeiXin_Views_Member_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Net\Desktop\WeiXin\ZZB.Core\ZZB.WebMVC.Core\Areas\WeiXin\Views\Member\Index.cshtml"
  
    ViewData["Title"] = "Index";
    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"card\" >\r\n    <div class=\"card-body table-responsive\">\r\n        <table class=\"table table-hover text-nowrap\">\r\n            <thead>\r\n                <tr>\r\n                    <th><el-checkbox name=\"type\"");
            BeginWriteAttribute("style", " style=\"", 264, "\"", 272, 0);
            EndWriteAttribute();
            WriteLiteral("></el-checkbox></th>\r\n                    <th>文件名</th>\r\n                    <th>大小</th>\r\n                    <th>共享</th>\r\n                    <th>修改日期</th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
            WriteLiteral("\r\n            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"

    <script>
        var page = new Vue({
            el: ""#app"",
            data() {
                return {
                    tableData: [],
                }
            },
            created() {
                this.Init();
            },
            methods: {
                Init() {
                    var that = this;
                    $.post(""UserList"", function (res) {
                        console.log(res)
                        that.tableData = res;
                    });
                }
            }
        })
    </script>
");
            }
            );
            WriteLiteral("\r\n\r\n");
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
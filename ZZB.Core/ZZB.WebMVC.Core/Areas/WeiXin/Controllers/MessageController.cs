using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZZB.BLL.WX_Servies;

namespace ZZB.WebMVC.Core.Areas.WeiXin.Controllers
{

    [Area("WeiXin")]
    [Route("/weixin/message/[action]")]
    public class MessageController : Controller
    {

        static Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IConfiguration _configuration;

        private string AppToken => _configuration.GetSection("WeiXin:AppToken").Value;

        public MessageController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // GET: WeiXinReplay
        public ActionResult Index(string signature, string timestamp, string nonce, string echostr)
        {
            Logger.Info($"signature:{signature}   / timestamp:{timestamp}   /  nonce:{nonce} / echostr :{echostr}");

            if (string.IsNullOrEmpty(echostr))
            {
                //自动回复
            }


            Logger.Info($"AppToken:{AppToken}  ");

            //验证
            if (string.IsNullOrEmpty(AppToken)) return Content("请先设置Token！");

            var ent = "";
            if (!WeiXinCheck.CheckSignature(signature, timestamp, nonce, AppToken, out ent))
            {
                return Content("参数错误！");
            }
            Logger.Info($"echostr:{echostr}  ***************************************************************8888888888");
            return Content(echostr); //返回随机字符串则表示验证通过

            //var tonken = _weiXinService.GetAccess_token();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeiXin.Server.Tool;
using WeiXin.Server.WX_Servies;

namespace WeiXin.Web.Controllers
{
    public class WeiXinReplayController : Controller
    {
        private string AppToken = ConfigHelper.GetConfigString("AppToken");
        private readonly WeiXinService _weiXinService;
        public WeiXinReplayController(WeiXinService weiXinService)
        {
            _weiXinService = weiXinService;
        }

        // GET: WeiXinReplay
        public ActionResult Index(string signature, string timestamp, string nonce, string echostr)
        {

            if (string.IsNullOrEmpty(AppToken)) return Content("请先设置Token！");

            var ent = "";
            if (!WeiXinCheck.CheckSignature(signature, timestamp, nonce, AppToken, out ent))
            {
                return Content("参数错误！");
            }
            return Content(echostr); //返回随机字符串则表示验证通过

            //var tonken = _weiXinService.GetAccess_token();

            return Content(echostr);
        }

    }
}
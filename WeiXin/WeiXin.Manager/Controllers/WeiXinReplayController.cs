using System.Web.Mvc;
using WeiXin.BLL;

namespace WeiXin.Manager.Controllers
{
    public class WeiXinReplayController : Controller
    {
        // GET: WeiXinReplay
        public ActionResult Index(string signature, string timestamp, string nonce, string echostr)
        {

            //if (string.IsNullOrEmpty(SNFWeiXinProcess.TOKEN)) return Content("请先设置Token！");

            //var ent = "";
            //if (!WeiXinCheck.CheckSignature(signature, timestamp, nonce, SNFWeiXinProcess.TOKEN, out ent))
            //{
            //    return Content("参数错误！");
            //}
            //return Content(echostr); //返回随机字符串则表示验证通过

            WeiXinService weiXinService = new WeiXinService();
            var tonken = weiXinService.GetAccess_token();
            
            return Content(echostr);
        }

    }
}
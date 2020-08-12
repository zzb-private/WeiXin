using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WeiXin.Server.WX_Servies;

namespace WeiXin.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly WeiXinService _weiXinService;

        public HomeController(WeiXinService weiXinService)
        {
            _weiXinService = weiXinService;
        }
        public async Task<ActionResult> Index()
        {
            //var data = await _weiXinService.GetAccess_token();
            //var ss = await _weiXinService.SetMenu();
            var data = await _weiXinService.GetUserList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZZB.BLL.WX_IServies;

namespace ZZB.WebMVC.Core.Areas.WeiXin.Controllers
{
    [Area("WeiXin")]
    [Route("/weixin/menu/[action]")]
    public class MenuController : Controller
    {
        private readonly IWeiXinService _weiXinService;

        public MenuController(IWeiXinService weiXinService)
        {
            _weiXinService = weiXinService;
        }

        public IActionResult Index()
        {
            var dd = _weiXinService.SetMenu("");
            return View();
        }
    }
}

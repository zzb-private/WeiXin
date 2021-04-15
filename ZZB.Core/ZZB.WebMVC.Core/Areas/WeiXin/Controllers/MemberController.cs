using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZZB.BLL.WX_IServies;
using ZZB.BLL.WX_Servies;
using ZZB.WebMVC.Core.Controllers;

namespace ZZB.WebMVC.Core.Areas.WeiXin.Controllers
{
    [Area("WeiXin")]
    [Route("/weixin/mermber/[action]")]
    public class MemberController : Controller
    {
        private readonly IWeiXinService _weiXinService;

        public MemberController(IWeiXinService weiXinService)
        {
            _weiXinService = weiXinService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.token = await _weiXinService.GetAccess_token();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserList()
        {
            var data = await _weiXinService.GetUserList();
            return Json(data);
        }
    }
}

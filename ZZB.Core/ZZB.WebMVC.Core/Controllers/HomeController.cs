using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ZZB.BLL.IRepositories.Admin;
using ZZB.DAL;
using ZZB.WebMVC.Core.Models;

namespace ZZB.WebMVC.Core.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        //private readonly IUserRepository _userRepository;

        //public HomeController(ILogger<HomeController> logger, 
        //    IUserRepository userRepository)
        //{
        //    _logger = logger;
        //    _userRepository = userRepository;
        //}

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(string name, string pass)
        {
            ////数据库验证登录人
            //if (await _userRepository.AnyAsync(p => p.AccountID == name && pass == p.PassWork))
            //{
            //    var data = await _userRepository.FirstOrDefaultAsync(p => p.AccountID == name && pass == p.PassWork);
            //    //添加cookie
            //    var claimidentity = new ClaimsIdentity("Cookies");//类似于构造一个用户信息对象
            //    claimidentity.AddClaim(new Claim("Name", data.UserName));
            //    claimidentity.AddClaim(new Claim("Pass", pass));
            //    claimidentity.AddClaim(new Claim("AccountID", data.AccountID));
            //    claimidentity.AddClaim(new Claim("Id", data.Id.ToString()));

            //    var claimsPrincipal = new ClaimsPrincipal(claimidentity);//构造一个证件
            //    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
            //}
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> LoginOut(string name, string pass)
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login");
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

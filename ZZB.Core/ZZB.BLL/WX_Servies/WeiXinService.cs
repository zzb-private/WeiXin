using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;
using ZZB.BLL.Tool;
using ZZB.BLL.WeiXin;
using ZZB.BLL.WX_IServies;
using ZZB.BLL.WX_Model.User;
using ZZB.DAL;
using ZZB.DAL.WeiXin;

namespace ZZB.BLL.WX_Servies
{
    public class WeiXinService: IWeiXinService
    {
        private readonly ZZBDbContext _weiXinDb;
        private readonly WeiXinApi WeiXinApi = new WeiXinApi();
        //private string AppID = ConfigHelper.GetConfigString("AppID");
        //private string AppSecret = ConfigHelper.GetConfigString("AppSecret");
        //private readonly CaCheHelper _cache;
        private readonly IConfiguration _configuration;
        private readonly IMemoryCache _cache;

        string AppID => _configuration.GetSection("WeiXin:AppID").Value;
        string AppSecret => _configuration.GetSection("WeiXin:AppSecret").Value;


        public WeiXinService(ZZBDbContext weiXinDb,
            IConfiguration configuration, IMemoryCache cache)
        {
            _weiXinDb = weiXinDb;
            _configuration = configuration;
            _cache = cache;
        }


        /// <summary>
        /// 获取Access_token
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetAccess_token()
        {
            var Cathtoken = _cache.Get("AppToken");
            if (Cathtoken == null)
            {
                var data = _weiXinDb.WeiXinConfigs.FirstOrDefault(p => p.AppId == AppID);
                if (data == null)
                    return null;
                if (data.Token_EndDate.HasValue)
                {
                    if (data.Token_EndDate.Value.AddMinutes(-10) > DateTime.Now)
                    {
                        _cache.Set("AppToken",data.Token);
                        return data.Token;
                    }
                }
                var token = await WeiXinApi.GetAccess_token(AppID, AppSecret);
                if (token == null)
                    return null;
                data.Token = token;
                data.Token_EndDate = DateTime.Now.AddHours(2);
                _weiXinDb.SaveChanges();
                _cache.Set("AppToken", data.Token);
                return data.Token;
            }
            return Cathtoken.ToString();
        }

        /// <summary>
        /// 设置菜单
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SetMenu(object data)
        {
            var token = await GetAccess_token();
            return await WeiXinApi.UpdateMenu(token,null);
        }

        /// <summary>
        /// 获取粉丝列表
        /// </summary>
        /// <returns></returns>
        public async Task<UserInfo> GetUserList()
        {
            var token = await GetAccess_token();
            var userlist = await WeiXinApi.GetUserList(token,null);
            //foreach (var i in userlist.data.openid)
            //{
            //    i.
            //}
            return userlist;
        }

        /// <summary>
        /// 添加永久素材
        /// </summary>
        /// <returns></returns>
        public async Task<string> AddFile(mediaType mediaType ,string FileName,byte[] bytes)
        {
            var token = await GetAccess_token();
            return await WeiXinApi.AddFile(token, mediaType, FileName,bytes);
        }


    }
}

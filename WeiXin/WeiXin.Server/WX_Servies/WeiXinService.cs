using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeiXin.DAL;
using WeiXin.Server.Tool;
using WeiXin.Server.WeiXin;

namespace WeiXin.Server.WX_Servies
{
    public class WeiXinService
    {
        private readonly WeiXinDbContext _weiXinDb;
        private readonly WeiXinApi WeiXinApi;
        private string AppID = ConfigHelper.GetConfigString("AppID");
        private string AppSecret = ConfigHelper.GetConfigString("AppSecret");


        public WeiXinService(WeiXinDbContext weiXinDb, WeiXinApi weiXinApi)
        {
            _weiXinDb = weiXinDb;
            WeiXinApi = weiXinApi;
        }


        /// <summary>
        /// 获取Access_token
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetAccess_token()
        {
            var Cathtoken = CaCheHelper.GetCache("AppToken");
            if (Cathtoken == null)
            {
                var data = _weiXinDb.WeiXinConfigs.FirstOrDefault(p => p.AppId == AppID);
                if (data == null)
                    return null;
                if (data.Token_EndDate.HasValue)
                {
                    if (data.Token_EndDate.Value.AddMinutes(-10) > DateTime.Now)
                    {
                        CaCheHelper.SetCache("AppToken",data.Token);
                        return data.Token;
                    }
                }
                var token = await WeiXinApi.GetAccess_token(AppID, AppSecret);
                if (token == null)
                    return null;
                data.Token = token;
                data.Token_EndDate = DateTime.Now.AddHours(2);
                _weiXinDb.SaveChanges();
                CaCheHelper.SetCache("AppToken", data.Token);
                return data.Token;
            }
            return Cathtoken.ToString();
        }

        /// <summary>
        /// 设置菜单
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SetMenu()
        {
            var token = "";
            var data = _weiXinDb.WeiXinConfigs.FirstOrDefault(p => p.AppId == AppID);
            if (data.Token_EndDate.HasValue)
            {
                if (data.Token_EndDate.Value.AddMinutes(-10) < DateTime.Now)
                {
                    token =  data.Token;
                }
            }
            token = await GetAccess_token();
            return await WeiXinApi.UpdateMenu(token,null);
        }

        /// <summary>
        /// 获取粉丝列表
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetUserList()
        {
            var token = await GetAccess_token();
            return await WeiXinApi.GetUserList(token,null);
        }

    }
}

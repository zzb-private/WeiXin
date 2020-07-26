using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WeiXin.BLL.Tool;
using WeiXin.BLL.WX_API;
using WeiXin.DAL;
using WeiXin.DAL.WeiXin;

namespace WeiXin.BLL
{
    public class WeiXinService
    {
        public static WeiXinDbContext _weiXinDb { get; set; }

        private static string AppID = ConfigHelper.GetConfigString("AppID");
        private static string AppSecret = ConfigHelper.GetConfigString("AppSecret");


        public WeiXinService()
        {
            _weiXinDb = new WeiXinDbContext();
        }

        public WeiXinService(string appid)
        {
            AppID = appid;
            _weiXinDb = new WeiXinDbContext();
        }


        /// <summary>
        /// 读取Access_token
        /// </summary>
        /// <returns></returns>
        public string GetAccess_token()
        {
            var data = _weiXinDb.WeiXinConfigs.FirstOrDefault(p => p.AppId == AppID);
            if (data == null)
                return null;
            if (data.Token_EndDate.HasValue)
            {
                if (data.Token_EndDate.Value.AddMinutes(-10) < DateTime.Now)
                {
                    return data.Token;
                }
            }
            var token = WeiXinApi.GetAccess_token(AppID,AppSecret);

            data.Token = token;
            data.Token_EndDate = DateTime.Now.AddHours(2);
            return token;
        }

        
    }
}

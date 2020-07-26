using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WeiXin.BLL.WX_API
{
    public class WeiXinApi
    {
        /// <summary>
        /// 获取Access_token
        /// https请求方式: 
        /// GET https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=APPID&secret=APPSECRET
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static string GetAccess_token(string APPID ,string APPSECRET)
        {
            try
            {
                Uri uri = new Uri($"https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={APPID}&secret={APPSECRET}");
                WebClient webClient = new WebClient();
                var token = webClient.DownloadString(uri);
                return token;
            }
            catch (Exception E)
            {
                return null;
            }
        }
    }
}

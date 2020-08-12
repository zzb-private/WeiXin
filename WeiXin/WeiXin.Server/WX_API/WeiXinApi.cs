using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WeiXin.Server.WX_Model.Menu;
using WeiXin.Server.WX_Servies;

namespace WeiXin.Server.WeiXin
{
    public class WeiXinApi
    {

        /// <summary>
        /// 获取Access_token
        /// https请求方式: 
        /// GET https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=APPID&secret=APPSECRET
        /// 问题1、：返回错误码：40164 ， 必须上登录公众平台，进入开发->基本配置页面-设置白名单
        /// 返回错误类型：
        /// {{
        ///   "errcode": 40125,
        ///   "errmsg": "invalid appsecret, view more at http://t.cn/RAEkdVq hint: [BepdbOwFE-3zAnFa] rid: 5f236e23-0ee231ea-5c4a7398"
        /// }}
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async static Task<string> GetAccess_token(string APPID, string APPSECRET)
        {
            try
            {
                Uri uri = new Uri($"https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={APPID}&secret={APPSECRET}");
                WebClient webClient = new WebClient();
                var token = await webClient.DownloadStringTaskAsync(uri);
                var json = JObject.Parse(token);
                if (json["errcode"] != null)
                {
                    LogWrite(json["errmsg"].ToString()) ;
                    return null;
                }
                return json["access_token"].ToString();
            }
            catch (Exception E)
            {
                return null;
            }
        }

        /// <summary>
        /// 自定义菜单
        /// </summary>
        /// <param name="APPID"></param>
        /// <param name="APPSECRET"></param>
        /// <returns></returns>
        public async Task<bool> UpdateMenu(string token,object data)
        {
            try
            {
                var ret = new MenuModel()
                {
                    button = new List<MenuBtn>()
                };
                ret.button.Add(new MenuBtn()
                {
                    type = "click",
                    name = "测试",
                    key = "V1001_TODAY_MUSIC"
                });

                ret.button.Add(new MenuBtn()
                {
                    type = "click",
                    name = "测试2",
                    key = "V1001_TODAY_MUSIC"
                });
                Uri uri = new Uri($" https://api.weixin.qq.com/cgi-bin/menu/create?access_token={token}");

                var json = await PostApi(uri, data);
                if (json["errcode"] != null)
                {
                    LogWrite(json["errmsg"].ToString());
                    return false;
                }
                return true;
            }
            catch (Exception E)
            {
                return false;
            }
        }

        /// <summary>
        /// 获取用户列表
        /// https://api.weixin.qq.com/cgi-bin/user/get?access_token=ACCESS_TOKEN&next_openid=NEXT_OPENID
        /// 每次最多拉取1000人，想要第1001个，填写next_openid值=“=NEXT_OPENID1”
        /// </summary>
        /// <param name="token"></param>
        /// <param name="next_openid">第一个拉取的OPENID，不填默认从头开始拉取</param>
        /// <returns></returns>
        public async Task<string> GetUserList(string token,string next_openid)
        {
            Uri uri = new Uri($"https://api.weixin.qq.com/cgi-bin/user/get?access_token={token}");

            var json = await GetApi(uri);
            if (json["errcode"] != null)
            {
                LogWrite(json["errmsg"].ToString());
                return null;
            }
            else
            {
                return json["openid"].ToString();
            }
        }


        private static async Task<JObject> PostApi(Uri uri ,object data)
        {
            HttpClient client = new HttpClient();
            var str = JsonConvert.SerializeObject(data);

            HttpContent content = new StringContent(str);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await client.PostAsync(uri, content);
            string responseBody = await response.Content.ReadAsStringAsync();

            return JObject.Parse(responseBody);
        }

        public static async Task<JObject> GetApi(Uri uri)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(uri);
            string responseBody = await response.Content.ReadAsStringAsync();
            return JObject.Parse(responseBody);
        }


















        /// <summary>
        /// 记录日志
        /// </summary>
        public static void LogWrite(string mess) { 

        }
    }
}

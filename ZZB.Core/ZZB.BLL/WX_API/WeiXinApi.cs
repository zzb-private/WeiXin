using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Threading.Tasks;
using ZZB.BLL.Tool;
using ZZB.BLL.WX_Model.Menu;
using ZZB.BLL.WX_Model.User;
using ZZB.DAL.WeiXin;

namespace ZZB.BLL.WeiXin
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
                MenuModelParam ret = new MenuModelParam()
                {
                    button = new MenuBtnParam[1]
                };
                ret.button[0] = new MenuBtnParam()
                {
                    type = "click",
                    name = "测试2",
                    key = "V1001_TODAY_MUSIC"
                };


                //MenuModelBase[] _model = new MenuModelBase[1]; 
                ////_model[0] = new MenuView { name = "百度音乐", url = "" };
                //_model[0] = new MenuClick { name = "冷笑话1", key = "TEST_1" };
                ////MenuModelBase[] _sub = new MenuModelBase[2];
                ////_sub[0] = new MenuView { name = "百度", url = "" }; 
                ////_sub[1] = new MenuView { name = "谷歌", url = "" }; 
                ////_model[2] = new MenuSub { name = "搜索导航", sub_button = _sub };
                //MenuButton bt = new MenuButton(); 
                //bt.button = _model;

                Uri uri = new Uri($" https://api.weixin.qq.com/cgi-bin/menu/create?access_token={token}");

                var responseBody = await HttpClientHelper.PostApi(uri, ret);
                var json = JObject.Parse(responseBody);
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
        /// {
        ///    "total":2,
        ///    "count":2,
        ///    "data":{
        ///    "openid":["OPENID1","OPENID2"]
        ///    },
        ///    "next_openid":"NEXT_OPENID"
        /// }
        /// </summary>
        /// <param name="token"></param>
        /// <param name="next_openid">第一个拉取的OPENID，不填默认从头开始拉取</param>
        /// <returns></returns>
        public async Task<UserInfo> GetUserList(string token,string next_openid)
        {
            Uri uri = new Uri($"https://api.weixin.qq.com/cgi-bin/user/get?access_token={token}");

            var responseBody = await HttpClientHelper.GetApi(uri);
            var json = JObject.Parse(responseBody);
            if (json["errcode"] != null)
            {
                LogWrite(json["errmsg"].ToString());
                return null;
            }
            else
            {
                var list = JsonConvert.DeserializeObject<UserInfo>(responseBody);
                //foreach (var i in list.data.openid)
                //{
                //    var ds = await GetUserInfo(token, i);
                //}
                return list;
            }
        }

        /// <summary>
        /// 获取用户详细信息
        /// </summary>
        /// <param name="token"></param>
        /// <param name="openid"></param>
        /// <param name="lang"></param>
        /// <returns></returns>
        public async Task<WX_UserInfo> GetUserInfo(string token, string openid, string lang = "zh_CN")
        {
            Uri uri = new Uri($"https://api.weixin.qq.com/cgi-bin/user/info?access_token={token}&openid={openid}&lang={lang}");

            var responseBody = await HttpClientHelper.GetApi(uri);
            var json = JObject.Parse(responseBody);
            if (json["errcode"] != null)
            {
                LogWrite(json["errmsg"].ToString());
                return null;
            }
            else
            {
                var list = JsonConvert.DeserializeObject<WX_UserInfo>(responseBody);
                return list;
            }
        }

        /// <summary>
        /// 添加永久素材
        /// https://api.weixin.qq.com/cgi-bin/material/add_material?access_token=ACCESS_TOKEN&type=TYPE 
        /// </summary>
        /// <returns></returns>
        public async Task<string> AddFile(string token, mediaType Type,string fileName,byte[] bytes)
        {
            //https://api.weixin.qq.com/cgi-bin/material/add_material?access_token=ACCESS_TOKEN&type=TYPE 
            Uri uri = new Uri($"https://api.weixin.qq.com/cgi-bin/material/add_material?access_token={token}&type=TYPE{Type.ToString()}");
            var data = await HttpClientHelper.HttpUploadFile(uri.ToString(), fileName, bytes);
            return "";
        }


        /// <summary>
        /// 记录日志
        /// </summary>
        public static void LogWrite(string mess) { 

        }
    }
}

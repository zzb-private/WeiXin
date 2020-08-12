using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiXin.Server.WX_Model.Menu
{
    /// <summary>
    /// 自定义菜单接口可实现多种类型按钮
    /// 
    /// 
    /// click：  点击推事件用户
    /// view：   跳转URL
    /// scancode_push：  扫码推事件
    /// media_id：       下发消息（除文本消息）
    /// view_limited：   跳转图文消息URL
    /// </summary>
    public class MenuBtn
    {
        public string type { get; set; }//类型：click/view ......
        public string name { get; set; }

        public List<MenuBtn> sub_button { get; set; }

        //type为miniprogram（跳转到小程序）类型必须
        public string appid { get; set; }
        public string pagepath { get; set; }

        //click等点击类型必须
        public string key { get; set; }

        //view、miniprogram类型必须
        public string url { get; set; }

        //media_id类型和view_limited类型必须
        public string media_id { get; set; }
        
    }
}

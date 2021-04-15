using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZZB.DAL.WeiXin
{
    public class WX_Menu: BaseEntity<int>
    {
        public WX_Menu()
        {
            SubMenu = new HashSet<WX_Menu>();
        }
        /// <summary>
        /// 父节点
        /// </summary>
        public int ParentId { get; set; }

        public string MenuName { get; set; }

        public WX_Btn_Type Btn_Type { get; set; }

        public Wx_Btn_Content_Type Content_Type{ get; set; }

        public string Content { get; set; }

        public string Media_id { get; set; }//图片路径

        public string Url { get; set; }//跳转路径/小程序路径

        public virtual IEnumerable<WX_Menu> SubMenu { get; set; }

    }

    public enum Wx_Btn_Content_Type
    {
        图文,
        图片,
        音频,
        视频,
    }

    public enum WX_Btn_Type
    {
        click,
        view,
        scancode_push,
        scancode_waitmsg,
        pic_sysphoto,
        pic_photo_or_album,
        pic_weixin,
        location_select,
    }
}


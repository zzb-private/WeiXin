using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZZB.DAL.WeiXin
{

    public class WX_UserInfo:BaseEntity<int>
    {
        public int subscribe { get; set; }
        public string openid { get; set; }
        public string nickname { get; set; }
        public int sex { get; set; }
        public string language { get; set; }
        public string city { get; set; }
        public string province { get; set; }
        public string country { get; set; }
        public string headimgurl { get; set; }
        public string subscribe_time { get; set; }
        public string unionid { get; set; }
        public string remark { get; set; }
        public int groupid { get; set; }
        public string subscribe_scene { get; set; }
        public int qr_scene { get; set; }
        public string qr_scene_str { get; set; }

        [NotMapped]
        public List<int> tagid_list { get; set; }

    }

    public class WX_UserTag
    {
        public List<int> tagid { get; set; }
    }
}

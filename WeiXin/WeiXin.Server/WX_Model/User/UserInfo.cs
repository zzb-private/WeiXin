using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiXin.Server.WX_Model.User
{
    public class UserInfo
    {
        public string total { get; set; }
        public int count { get; set; }
        public UserId data { get; set; }
        public int next_openid { get; set; }
    }
    public class UserId
    {
        public List<string> openid { get; set; }
    }
}

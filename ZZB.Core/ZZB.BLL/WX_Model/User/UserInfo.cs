using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZZB.BLL.WX_Model.User
{
    public class UserInfo
    {
        public int total { get; set; }
        public int count { get; set; }
        public UserId data { get; set; }
        public string next_openid { get; set; }
    }
    public class UserId
    {
        public List<string> openid { get; set; }
    }
}

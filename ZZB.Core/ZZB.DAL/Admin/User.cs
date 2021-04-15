using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZZB.DAL.Admin
{
    public class User:BaseEntity<int>
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string AccountID { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string PassWork { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        public bool? IsAdministrator { get; set; }
        /// <summary>
        /// 绰号
        /// </summary>
        public string Alias_name { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public UserStatus? Status { get; set; }

        public bool? IsLogin { get; set; }
    }

    public enum UserStatus
    {
        正常,
        停用,
    }
}

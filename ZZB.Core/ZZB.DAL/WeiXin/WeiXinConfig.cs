using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZZB.DAL.WeiXin
{
    [Table("WeiXinConfigs")]
    public class WeiXinConfig: BaseEntity<int>
    {
        public string AppId { get; set; }

        public string Token { get; set; }

        public DateTime? Token_EndDate { get; set; }

        public string AppSecret { get; set; }
    }
}

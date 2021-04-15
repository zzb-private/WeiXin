using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZZB.BLL.Tool
{
    public  class ReturnJson
    {
        public  bool isok { get; set; }
        public  string mess { get; set; }
        public  object data { get; set; }

        public static ReturnJson Create(bool isok = true, string mess = null,object data = null)
        {
            return new ReturnJson()
            {
                isok = isok,
                data = data,
                mess = mess ?? (isok ? "成功":"失败"),
            };
        }

    }
}

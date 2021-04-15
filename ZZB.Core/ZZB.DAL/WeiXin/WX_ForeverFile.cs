using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZZB.DAL.WeiXin
{
    /// <summary>
    /// 永久素材
    /// </summary>
    public class WX_ForeverFile
    {
        public int Id { get; set; }

        public string AppId { get; set; }

        public mediaType mediatype { get; set; }

        public string mediaid { get; set; }

        public string url { get; set; }
    }


    public enum mediaType
    {
        image = 0,//image,
        voice = 1,
        video = 2,
        thumb = 3

    }
}

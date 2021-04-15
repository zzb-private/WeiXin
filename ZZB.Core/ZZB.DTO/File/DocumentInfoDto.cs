using System;
using System.Collections.Generic;
using System.Text;

namespace ZZB.DTO.File
{
    public class DocumentInfoDto:BaseDto<int>
    {
        public int? DocumentInfoId { get; set; }

        /// <summary>
        /// 是否文件夹
        /// </summary>
        public bool IsFolder { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string ICon { get; set; }

        /// <summary>
        /// 是否共享
        /// </summary>
        public string IsShare { get; set; }

        /// <summary>
        /// 文件大小
        /// </summary>
        public int FileSize { get; set; }
        public string FileUri { get; set; }
        public string FileType { get; set; }
    }
}

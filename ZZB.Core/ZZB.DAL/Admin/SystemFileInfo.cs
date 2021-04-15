using System;
using System.Collections.Generic;
using System.Text;

namespace ZZB.DAL.Admin
{
    public class SystemFileInfo: BaseEntity<int>
    {
        public string UploaderId { get; set; }
        public string DisplayName { get; set; }
        public string FileName { get; set; }
        public string FileFullName { get; set; }
        public string HashCode { get; set; }
        public string Uri { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        public long FileSize { get; set; }
        public DateTime CreationTime { get; set; }
    }
}

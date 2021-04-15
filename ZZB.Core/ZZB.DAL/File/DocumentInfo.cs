using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ZZB.DAL.Admin;

namespace ZZB.DAL.File
{
    public class DocumentInfo : BaseEntity<int>
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }

        //[ForeignKey(nameof(UserId))]
        //public virtual User User { get; set; }

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
        public bool IsShare { get; set; }


        public int? FileId { get; set; }
        [ForeignKey(nameof(FileId))]
        public virtual SystemFileInfo SystemFileInfo { get; set; }


        public int? DocumentInfoId { get; set; }
        [ForeignKey(nameof(DocumentInfoId))]
        public virtual List<DocumentInfo> DocumentInfos{ get; set; }

    }
}

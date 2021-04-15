using System;
using System.Collections.Generic;
using System.Text;

namespace ZZB.DTO
{
    public class BaseDto<T>
    {
        public T Id { get; set; }
        public DateTime? ModifyDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public string ModifyDateStr { get { return ModifyDate.HasValue ? ModifyDate.Value.ToString("yyyy-MM-dd HH:mm:ss"):""; } }
        public string CreateDateStr { get { return CreateDate.HasValue ? CreateDate.Value.ToString("yyyy-MM-dd HH:mm:ss"):""; } }


        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }
    }
}

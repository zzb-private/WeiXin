using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ZZB.DTO
{
    public abstract class ParamDto
    {
        public virtual int PageSize { get; set; } = 10;
        public int PageIndex { get; set; } = 1;

        public string Search { get; set; }
    }
}

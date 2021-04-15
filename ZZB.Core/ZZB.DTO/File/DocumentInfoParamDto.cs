using System;
using System.Collections.Generic;
using System.Text;

namespace ZZB.DTO.File
{
    public class DocumentInfoParamDto: ParamDto
    {
        public int? DocumentId { get; set; }

        public override int PageSize { get; set; } = int.MaxValue;

    }
}

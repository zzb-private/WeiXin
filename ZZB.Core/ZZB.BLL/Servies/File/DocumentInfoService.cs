using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using ZZB.BLL.IRepositories.File;
using ZZB.DAL;
using ZZB.DAL.File;
using ZZB.DTO.File;

namespace ZZB.BLL.Servies.File
{
    public class DocumentInfoService : BaseService<ZZBDbContext, DocumentInfo, DocumentInfoDto>, IDocumentInfoRepository
    {
        public DocumentInfoService(ZZBDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {

        }
    }
}

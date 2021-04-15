using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZZB.DAL.File;
using ZZB.DTO.File;

namespace ZZB.WebMVC.Core.AutoMapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<DocumentInfo, DocumentInfoDto>()
                .ForMember(x=>x.FileSize,src=>src.MapFrom(p=>p.IsFolder?0:p.SystemFileInfo.FileSize))
                .ForMember(x=>x.FileUri,src=>src.MapFrom(p=>p.IsFolder?"":p.SystemFileInfo.Uri))
                //.ForMember(x=>x.FileType,src=>src.MapFrom(p=>p.IsFolder?"":p.SystemFileInfo.))
                .ReverseMap();
        }
    }
}

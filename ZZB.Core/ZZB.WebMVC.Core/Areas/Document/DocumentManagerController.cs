using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZZB.BLL.IRepositories.File;
using ZZB.BLL.Servies.File;
using ZZB.DAL.File;
using ZZB.DTO.File;
using ZZB.WebMVC.Core.Controllers;

namespace ZZB.WebMVC.Core.Area.Document
{
    [Route("Document/[controller]/[action]")]
    [Authorize]
    public class DocumentManagerController : BaseController
    {
        private readonly IDocumentInfoRepository _documentInfoService;
        private readonly IMapper _mapper;

        public DocumentManagerController(IDocumentInfoRepository documentInfoService, 
            IMapper mapper)
        {
            _documentInfoService = documentInfoService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddFolder(DocumentInfo model)
        {
            model.UserId = CurrentUser.Id;
            //base.HttpContext.RequestServices
            await _documentInfoService.SaveEntityAsync(model);
            return await OkAsync(_documentInfoService.Result);
        }

        public async Task<IActionResult> GetDocumentList(DocumentInfoParamDto param)
        {
            var data = await _documentInfoService.ListDataPageAsync(param, 
                p => (p.DocumentInfoId == param.DocumentId)
                && p.UserId == CurrentUser.Id
                && (param.Search == null || p.Name.Contains(param.Search))
            );
            return await OkAsync(_documentInfoService.Result, data);
        }
    }
}

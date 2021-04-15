using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ZZB.BLL.Extensions;
using ZZB.BLL.IRepositories.File;
using ZZB.DAL.Admin;

namespace ZZB.WebMVC.Core.Controllers
{
    [Authorize]
    public class FileController : Controller
    {
        private readonly string admin = "admin";
        private readonly ISystemFileInfoRepository _fileRepository;
        private readonly IFileProvider _fileProvider;

        public FileController(ISystemFileInfoRepository fileRepository,
            IFileProvider fileProvider)
        {
            _fileRepository = fileRepository;
            _fileProvider = fileProvider;
        }

        public async Task<IActionResult> Index() {

            return View();
        }

        [HttpPost]
        public async Task<ActionResult<SystemFileInfo>> Upload([FromForm] IFormFile file)
        {
            await using var ms = new MemoryStream();
            await file.CopyToAsync(ms);
            //var image = await Image.LoadAsync(file.OpenReadStream());
            var bytes = ms.ToArray();
            ms.Close();

            var virtualPath = Path.Combine("Seller", admin);

            var fileInfo = await _fileRepository.AddAsync(_fileProvider.GetRoot(), virtualPath, file.FileName, bytes);

            return Ok(fileInfo);
        }

        [HttpPost]
        public async Task<IActionResult> UploadImagesToImageBank([FromForm] IFormFile file)
        {
            //var image = await Image.LoadAsync(file.OpenReadStream());

            //var fileName = $"{DateTimeUtility.ConvertToTimeStamp(DateTime.Now)}.png";
            var path = "UploadImage";

            var filePath = Path.Combine(AppContext.BaseDirectory, path);
            if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);

            var virtualPath = Path.Combine("Seller", admin);
            var fileInfo = await _fileRepository.AddAsync(_fileProvider.GetRoot(), virtualPath, file.FileName, file.OpenReadStream());

            return Ok(fileInfo);
        }
    }
}

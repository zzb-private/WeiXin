
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;
using ZZB.BLL.IRepositories.File;
using ZZB.DAL;
using ZZB.DAL.Admin;

namespace ZZB.BLL.Servies.File
{
    public class SystemFileInfoService: Repository<ZZBDbContext,SystemFileInfo>, ISystemFileInfoRepository
    {
        public SystemFileInfoService(ZZBDbContext dbContext):base(dbContext)
        {
        }
        public string userId => "admin";

        public async Task<SystemFileInfo> AddAsync(string root,string relativePath, string fileName, byte[] bytes)
        {
            var path = Path.Combine(root, relativePath);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (bytes.Length == 0) throw new ArgumentException(nameof(bytes));

            var hashCode = GetMd5HashCode(bytes);
            if (!await AnyAsync(x => x.HashCode == hashCode))
            {
                var extension = "";
                //处理文件名未携带后缀报错，默认给个 .png 后缀
                if (fileName.LastIndexOf(".", StringComparison.Ordinal) == -1)
                {
                    extension = ".png";
                }
                else
                {
                    extension = fileName.Substring(fileName.LastIndexOf(".", StringComparison.Ordinal));
                }
                var realFileName = Path.GetRandomFileName() + extension;
                var filePath = Path.Combine(path, realFileName);
                await using var fs = new FileStream(filePath, FileMode.Create);
                await fs.WriteAsync(bytes, 0, bytes.Length);
                fs.Close();

                var file = new SystemFileInfo
                {
                    CreationTime = DateTime.Now,
                    DisplayName = fileName,
                    FileName = realFileName,
                    FileFullName = filePath,
                    FileSize = bytes.Length,
                    HashCode = hashCode,
                    Uri = ConvertToUrlString($"/UploadFile/{relativePath}/{realFileName}"),
                    UploaderId = userId
                };
                await SaveEntityAsync(file);
                await DbSaveChangesAsync();
                return file;
            }

            return await FirstOrDefaultAsync(x => x.HashCode == hashCode);
        }

        public async Task<SystemFileInfo> AddAsync(string root,string relativePath, string fileName, Stream stream)
        {
            var path = Path.Combine(root, relativePath);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (stream.Length==0) throw new ArgumentException(nameof(stream));

            var hashCode = GetMd5HashCode(stream);
            if (!await AnyAsync(x => x.HashCode == hashCode))
            {
                var extension = fileName.Substring(fileName.LastIndexOf(".", StringComparison.Ordinal));
                var realFileName = Path.GetRandomFileName() + extension;
                var filePath = Path.Combine(path, realFileName);
                await using var fs = new FileStream(filePath, FileMode.Create);
                await stream.CopyToAsync(fs);

                //var fileInfo = new SystemFileInfo(Path.Combine(path, realFileName));
                var file = new SystemFileInfo
                {
                    CreationTime = DateTime.Now,
                    DisplayName = fileName,
                    FileName = realFileName,
                    FileFullName = filePath,
                    FileSize = stream.Length,
                    HashCode = hashCode,
                    Uri = ConvertToUrlString($"/UploadFile/{relativePath}/{realFileName}"),
                    UploaderId = userId
                };
                await SaveEntityAsync(file);
                await DbSaveChangesAsync();

                return file;
            }

            return await FirstOrDefaultAsync(x => x.HashCode == hashCode);
        }

        private static string GetMd5HashCode(Stream stream)
        {
            var md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            var bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            stream.Seek(0, SeekOrigin.Begin);
            var hash = md5.ComputeHash(bytes);

            var result = BitConverter.ToString(hash);
            result = result.Replace("-", "");
            md5.Clear();
            return result;
        }

        private static string GetMd5HashCode(byte[] bytes)
        {
            var md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();

            var hash = md5.ComputeHash(bytes);

            var result = BitConverter.ToString(hash);
            result = result.Replace("-", "");
            md5.Clear();
            return result;
        }

        private static string ConvertToUrlString(string path)
        {
            return path.Replace(@"\\", "/").Replace(@"\","/");
        }
    }
}

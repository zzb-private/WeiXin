
using System.IO;
using System.Threading.Tasks;
using ZZB.DAL.Admin;

namespace ZZB.BLL.IRepositories.File
{
    public interface ISystemFileInfoRepository:IRepository<SystemFileInfo>
    {
        Task<SystemFileInfo> AddAsync(string root,string relativePath, string fileName, byte[] bytes);
        Task<SystemFileInfo> AddAsync(string root,string relativePath, string fileName, Stream stream);
    }
}

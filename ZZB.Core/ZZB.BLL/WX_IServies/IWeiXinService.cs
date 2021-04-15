using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZZB.BLL.WX_Model.User;
using ZZB.DAL.WeiXin;

namespace ZZB.BLL.WX_IServies
{
    public interface IWeiXinService
    {
        Task<string> GetAccess_token();
        Task<bool> SetMenu(object data);
        Task<UserInfo> GetUserList();
        Task<string> AddFile(mediaType mediaType, string FileName, byte[] bytes);
    }
}

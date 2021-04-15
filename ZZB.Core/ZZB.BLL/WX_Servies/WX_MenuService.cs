using System.Collections.Generic;
using System.Linq;
using ZZB.BLL.WX_IServies;
using ZZB.DAL;
using ZZB.DAL.WeiXin;

namespace ZZB.BLL.WX_Servies
{
    public class WX_MenuService : IWX_Menu
    {

        private readonly ZZBDbContext xinDbContext;
        public WX_MenuService(ZZBDbContext xinDbContext)
        {
            this.xinDbContext = xinDbContext;
        }

        public List<WX_Menu> GetWX_Menus()
        {
            return xinDbContext.WX_Menus.ToList();
        }
    }
}

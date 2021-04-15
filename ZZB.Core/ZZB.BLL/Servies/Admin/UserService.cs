using System;
using System.Collections.Generic;
using System.Text;
using ZZB.BLL.IRepositories.Admin;
using ZZB.DAL;
using ZZB.DAL.Admin;

namespace ZZB.BLL.Servies.Admin
{
    public class UserService:  Repository<ZZBDbContext, User>, IUserRepository
    {
        public UserService(ZZBDbContext dbContext) : base(dbContext)
        {

        }
    }
}

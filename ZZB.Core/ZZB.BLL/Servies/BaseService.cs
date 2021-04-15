using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZZB.BLL.IRepositories;
using ZZB.DAL;
using ZZB.DTO;

namespace ZZB.BLL.Servies
{
    public class BaseService<TDbContext, T, TDto> : Repository<TDbContext, T, TDto>,  IBaseService<T, TDto> 
        where T : class, IEntity, new()
        where TDbContext : DbContext
    {
        protected readonly IMapper mapper;

        public ResultDto Result => new ResultDto();

        public BaseService(TDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            this.mapper = mapper;
        }

        public async Task<BaseTablePaging<TDto>> ListDataPageAsync(ParamDto param, 
            Expression<Func<T, bool>> whereLambda, 
            Expression<Func<T, object>> orderLambda = null, 
            bool isAsc = false)
        {
            var data = ListEntitiesWithPage(param.PageIndex, param.PageSize, out int temp, whereLambda, orderLambda, isAsc);
            var table = mapper.Map<List<T>, List<TDto>>(await data.ToListAsync());
            return new BaseTablePaging<TDto>(param.PageIndex, param.PageSize, temp, table);
        }


        public BaseTablePaging<TDto> ListDataPage(ParamDto param,
            Expression<Func<T, bool>> whereLambda,
            Expression<Func<T, object>> orderLambda = null,
            bool isAsc = false)
        {
            var data = ListEntitiesWithPage(param.PageIndex, param.PageSize, out int temp, whereLambda, orderLambda, isAsc);
            var table = mapper.Map<List<T>, List<TDto>>(data.ToList());
            return new BaseTablePaging<TDto>(param.PageIndex, param.PageSize, temp, table);
        }
    }
}

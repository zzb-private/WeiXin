using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZZB.DAL;
using ZZB.DTO;

namespace ZZB.BLL.IRepositories
{
    public interface IBaseService<T,TDto>:IRepository<T> where T: IEntity,new()
    {
        Task<BaseTablePaging<TDto>> ListDataPageAsync(ParamDto param,
            Expression<Func<T, bool>> whereLambda,
            Expression<Func<T, object>> orderLambda = null,
            bool isAsc = false);


        BaseTablePaging<TDto> ListDataPage(ParamDto param,
            Expression<Func<T, bool>> whereLambda,
            Expression<Func<T, object>> orderLambda = null,
            bool isAsc = false);

        ResultDto Result { get; }
    }
}

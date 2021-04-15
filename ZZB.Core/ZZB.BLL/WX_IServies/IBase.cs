using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ZZB.BLL.WX_IServies
{
    public interface IBase<T,Y>
    {
        T Add(T data);

        List<T> AddRange(List<T> data);

        bool Del(Y Id);

        bool Edit(T data);

        IEnumerable<T> GetList(Expression<Func<T,bool>> expression);

        bool Any(Expression<Func<T, bool>> expression);

        int Count(Expression<Func<T, bool>> expression);

        T GetFirst(Expression<Func<T, bool>> expression);
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Linq.Expressions;
using ZZB.BLL.WX_IServies;
using ZZB.DAL;

namespace ZZB.BLL.WX_Servies
{
    public class BaseSerivce<T,Y> : IBase<T,Y> where T : BaseEntity<Y>,new()
    {
        private readonly bool IsSuccess = true;
        private readonly string Message = "操作成功";
        private ZZBDbContext _weiXinDbContext /*= new WeiXinDbContext()*/;

        public T Add(T entity)
        {
            _weiXinDbContext.Set<T>().Add(entity);
            _weiXinDbContext.SaveChanges();
            return entity;
        }

        public bool Del(Y Id)
        {
            var data = _weiXinDbContext.Set<T>().Where(p => p.Id.Equals(Id)).FirstOrDefault();
            if (data == null)
                return false;
            _weiXinDbContext.Set<T>().Remove(data);
            return _weiXinDbContext.SaveChanges() > 0;
        }

        public bool Any(Expression<Func<T, bool>> expression)
        {
            return _weiXinDbContext.Set<T>().Any(expression);
        }

        public bool Edit(T entity)
        {
            if (Any(p => p.Id.Equals(entity.Id)))
            {
                _weiXinDbContext.Set<T>().Attach(entity);
                _weiXinDbContext.Entry<T>(entity).State = EntityState.Modified;
                _weiXinDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<T> GetList(Expression<Func<T, bool>> expression)
        {
            return _weiXinDbContext.Set<T>().Where(expression);
        }


        public T GetFirst(Expression<Func<T, bool>> expression)
        {
            return _weiXinDbContext.Set<T>().FirstOrDefault(expression);
        }

        public List<T> AddRange(List<T> entity)
        {
            _weiXinDbContext.Set<T>().AddRange(entity);
            _weiXinDbContext.SaveChanges();
            return entity;
        }

        public int Count(Expression<Func<T, bool>> expression)
        {
            return _weiXinDbContext.Set<T>().Where(expression).Count();
        }
    }
}

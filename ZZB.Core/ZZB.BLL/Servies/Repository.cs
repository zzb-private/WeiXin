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

    public class Repository<TDbContext, T, TDto> : Repository<TDbContext, T>,
        IRepository<T> where T : class, IEntity, new()
                       where TDbContext : DbContext
    {
        public Repository(TDbContext _dbcontext):base(_dbcontext)
        {
        }


    }
    public class Repository<TDbContext,T> : ApplicationService,
        IRepository<T> where T : class,IEntity,new ()
                       where TDbContext : DbContext
    {
        protected readonly TDbContext context;

        public Repository(TDbContext _dbcontext)
        {
            context = _dbcontext;
        }

        public IQueryable<T> Entities
        {
            get { return context.Set<T>().AsQueryable(); }
        }

        public bool Any(Expression<Func<T, bool>> whereLambda)
        {
            return context.Set<T>().Any(whereLambda);
        }

        public int Count(Expression<Func<T, bool>> whereLambda)
        {
            return ListEntities(whereLambda).Count();
        }

        public T FirstOrDefault(Expression<Func<T, bool>> whereLambda)
        {
            return ListEntities(whereLambda).FirstOrDefault();
        }

        public IQueryable<T> ListAllEntities()
        {
            return ListEntities(p => true);
        }

        public IQueryable<T> ListEntities(Expression<Func<T, bool>> whereLambda)
        {
            return context.Set<T>().Where<T>(whereLambda);
        }

        public IQueryable<TResult> ListEntities<TResult>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, TResult>> selector)
        {
            return context.Set<T>()
                            .Where<T>(whereLambda)
                            .Select(selector);
        }

        public IQueryable<T> ListEntitiesWithPage(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, object>> orderLambda, bool isAsc)
        {
            IQueryable<T> temp = null;
            if (orderLambda != null)
            {
                if (isAsc)
                {
                    temp = context.Set<T>().OrderBy(orderLambda).Where<T>(whereLambda);
                }
                else
                {
                    temp = context.Set<T>().OrderByDescending(orderLambda).Where<T>(whereLambda);
                }
            }
            else
            {
                temp = context.Set<T>().Where<T>(whereLambda);
            }
            totalCount = temp.Count();
            return temp.Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
        }


        public bool RemoveEntities(Expression<Func<T, bool>> whereLambda)
        {
            List<T> entites = ListEntities(whereLambda).ToList();
            context.Set<T>().RemoveRange(entites);
            DbSaveChanges();
            return true;
        }

        public IEnumerable<T> SaveEntities(IEnumerable<T> entities)
        {
            context.Set<T>().AddRange(entities);
            DbSaveChanges();
            return entities;
        }

        public void BulkInsert(IEnumerable<T> entities)
        {
            //context.BulkInsert(entities);
            //context.BulkSaveChanges( );
            throw new NotImplementedException("功能为实现!!");
        }

        public T SaveEntity(T entity)
        {
            context.Set<T>().Add(entity);
            DbSaveChanges();
            return entity;
        }

        public bool UpdateEntity(T entity)
        {
            context.Set<T>().Attach(entity);
            context.Entry<T>(entity).State = EntityState.Modified;
            DbSaveChanges();
            return true;
        }

        public int DbSaveChanges()
        {
            return context.SaveChanges();
        }

        public int UpdateEntities(Expression<Func<T, bool>> whereLambda, Expression<Func<T, T>> updateExpression)
        {
            //return context.Set<T>().Where(whereLambda).Update(updateExpression);
            throw new NotImplementedException("功能为实现!!");
        }

        #region 异步


        public async Task<bool> AnyAsync(Expression<Func<T, bool>> whereLambda)
        {
            return await context.Set<T>().AnyAsync(whereLambda);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> whereLambda)
        {
            return await ListEntities(whereLambda).CountAsync();
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> whereLambda)
        {
            return await ListEntities(whereLambda).FirstOrDefaultAsync();
        }


        public async Task<bool> RemoveEntitiesAsync(Expression<Func<T, bool>> whereLambda, string personCode)
        {
            IQueryable<T> entites = ListEntities(whereLambda);
            context.Set<T>().RemoveRange(entites);
            await DbSaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<T>> SaveEntitiesAsync(IEnumerable<T> entities)
        {
            await context.Set<T>().AddRangeAsync(entities);
            await DbSaveChangesAsync();
            return entities;
        }

        public void BulkInsertAsync(IEnumerable<T> entities)
        {
            //context.BulkInsert(entities);
            //context.BulkSaveChanges( );
            throw new NotImplementedException("功能为实现!!");
        }

        public async Task<bool> SaveEntityAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            return await DbSaveChangesAsync() > 0 ;
        }

        public async Task<bool> UpdateEntityAsync(T entity)
        {
            context.Set<T>().Attach(entity);
            context.Entry<T>(entity).State = EntityState.Modified;
            await DbSaveChangesAsync();
            return true;
        }

        public async Task<int> DbSaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }

        public async Task<int> UpdateEntitiesAsync(Expression<Func<T, bool>> whereLambda, Expression<Func<T, T>> updateExpression)
        {
            //return context.Set<T>().Where(whereLambda).Update(updateExpression);
            throw new NotImplementedException("功能为实现!!");
        }

        #endregion

    }

}

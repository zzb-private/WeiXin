using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZZB.DAL;

namespace ZZB.BLL.IRepositories
{
    public interface IRepository<T> 
        where T: IEntity, new ()
    {
    
        IQueryable<T> Entities { get; }

        /// <summary>
        /// 获取是否存在查询条件的数据
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        bool Any(Expression<Func<T, bool>> whereLambda);

        /// <summary>
        /// 查询记录数量
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        int Count(Expression<Func<T, bool>> whereLambda);

        /// <summary>
        /// 查询获取列表
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        IQueryable<T> ListEntities(Expression<Func<T, bool>> whereLambda);

        /// <summary>
        /// 查询获取列表（分页）
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <param name="whereLambda">条件过滤lambda表达式</param>
        /// <param name="orderLambda">排序lambda表达式</param>
        /// <param name="isAsc">是否升序</param>
        /// <returns></returns>
        IQueryable<T> ListEntitiesWithPage(int pageIndex, int pageSize, out int totalCount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, object>> orderLambda, bool isAsc);

        /// <summary>
        /// 删除对象
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <param name="personCode"></param>
        /// <returns></returns>
        bool RemoveEntities(Expression<Func<T, bool>> whereLambda);

        /// <summary>
        /// 添加对象
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
       T SaveEntity(T entity);

        /// <summary>
        /// 批量添加对象
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        IEnumerable<T> SaveEntities(IEnumerable<T> entities);

        /// <summary>
        /// 插入大量数据，不返回任何数据
        /// </summary>
        /// <param name="entities"></param>
        void BulkInsert(IEnumerable<T> entities);

        /// <summary>
        /// 更新对象，必须遵循先查询后修改的规则。
        /// 即使用FirstOrDefault查询后再通过UpdateEntity修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool UpdateEntity(T entity);

        /// <summary>
        /// 查询第一个对象，不存在返回null
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        T FirstOrDefault(Expression<Func<T, bool>> whereLambda);

        /// <summary>
        /// 查询所有对象
        /// </summary>
        /// <returns></returns>
        IQueryable<T> ListAllEntities();

        /// <summary>
        /// 自定义修改时提供保存操作
        /// </summary>
        /// <returns></returns>
        int DbSaveChanges();

        /// <summary>
        /// 批量更新数据库
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <param name="updateExpression"></param>
        /// <returns></returns>
        int UpdateEntities(Expression<Func<T, bool>> whereLambda, Expression<Func<T, T>> updateExpression);

        /// <summary>
        /// 查询获取列表，自定义查询列
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="whereLambda"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        IQueryable<TResult> ListEntities<TResult>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, TResult>> selector);


        Task<bool> AnyAsync(Expression<Func<T, bool>> whereLambda);

        Task<int> CountAsync(Expression<Func<T, bool>> whereLambda);

        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> whereLambda);

        Task<bool> RemoveEntitiesAsync(Expression<Func<T, bool>> whereLambda, string personCode);

        Task<IEnumerable<T>> SaveEntitiesAsync(IEnumerable<T> entities);

        void BulkInsertAsync(IEnumerable<T> entities);

        Task<bool> SaveEntityAsync(T entity);

        Task<bool> UpdateEntityAsync(T entity);

        Task<int> DbSaveChangesAsync();

        Task<int> UpdateEntitiesAsync(Expression<Func<T, bool>> whereLambda, Expression<Func<T, T>> updateExpression);
    }
}

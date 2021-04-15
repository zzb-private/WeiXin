using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ZZB.DTO
{
    public class BaseTablePaging<T>
    {
        public BaseTablePaging()
        {

        }
        public BaseTablePaging(int pageSize, int pageIndex, int dataCount, List<T> table)
        {
            PageSize = pageSize;
            PageIndex = pageIndex;
            DataCount = dataCount;
            Table = table;
            PageCount = DataCount % PageSize == 0 ? dataCount / pageSize : dataCount / pageSize + 1;
        }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int PageCount { get; set; }
        public int DataCount { get; set; }
        public List<T> Table { get; set; }

        public static BaseTablePaging<T> CreatePage(IQueryable<T> linq, int pageIndex, int pageSize, bool enable, string orderByFile = "id")
        {
            var count = linq.Count();
            var data = enable ? linq.Skip((pageIndex - 1) * pageSize).Take(pageSize).OrderBy(s => orderByFile).ToList() : linq.ToList();
            return new BaseTablePaging<T>(pageSize, pageIndex, count, data);
        }
        public static async Task<BaseTablePaging<T>> CreatePageAsync(IQueryable<T> linq, int pageIndex, int pageSize, bool enable, string orderByFile = "id")
        {
            var count = await linq.CountAsync();
            List<T> data = null;
            if (enable)
            {
                linq = linq.Skip((pageIndex - 1) * pageSize).Take(pageSize);
                if (orderByFile.Equals(ConstString.NotOrderBy))
                {

                }
                else
                {
                    linq = linq.OrderBy(s => orderByFile);
                }

                data = await linq.ToListAsync();
            }
            else
            {
                data = await linq.ToListAsync(); ;
            }
            return new BaseTablePaging<T>(pageSize, pageIndex, count, data);
        }


        public static class ConstString
        {
            public const string NotOrderBy = "NotOrderBy";
        }
    }
}

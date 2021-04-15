using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ZZB.BLL.Tool
{
    public class CaCheHelper
    {
        private IMemoryCache _cache;
 
     public CaCheHelper(IMemoryCache memoryCache)
     {
         _cache = memoryCache;
    }

    /// <summary>  
    /// 获取数据缓存  
    /// </summary>  
    /// <param name="cacheKey">键</param>  
    public object GetCache(string cacheKey)
        {
            var objCache = _cache.Get(cacheKey);
            return objCache;
        }
        /// <summary>  
        /// 设置数据缓存  
        /// </summary>  
        //public static void SetCache(string cacheKey, object objObject)
        //{
        //    var objCache = HttpRuntime.Cache;
        //    objCache.Insert(cacheKey, objObject);
        //}
        /// <summary>  
        /// 设置数据缓存  
        /// </summary>  
        public void SetCache(string cacheKey, object objObject, int timeout = 7200)
        {
            try
            {
                if (objObject == null) return;
                var objCache = _cache;
                //相对过期  
                //objCache.Insert(cacheKey, objObject, null, DateTime.MaxValue,  new TimeSpan(0, 0, timeout), CacheItemPriority.NotRemovable, null);  
                //绝对过期时间  
                _cache.Set(cacheKey, objObject, new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(timeout)));
            }
            catch (Exception)
            {
                //throw;  
            }
        }
        /// <summary>  
        /// 移除指定数据缓存  
        /// </summary>  
        public void RemoveAllCache(string cacheKey)
        {
            _cache.Remove(cacheKey);
        }
        /// <summary>  
        /// 移除全部缓存  
        /// </summary>  
        //public  void RemoveAllCache()
        //{
        //    var cacheEnum = _cache.k();
        //    while (cacheEnum.MoveNext())
        //    {
        //        _cache.Remove(cacheEnum.Key.ToString());
        //    }
        //}
    }
}

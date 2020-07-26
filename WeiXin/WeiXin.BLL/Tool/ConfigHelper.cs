using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Caching;

namespace WeiXin.BLL.Tool
{
    public class ConfigHelper
    {
        public static string GetConfigString(string key)
        {
            string cacheKey = "AppSettings-" + key;
            object obj = CaCheHelper.GetCache(cacheKey);
            if (obj == null)
            {
                try
                {
                    obj = ConfigurationManager.AppSettings[key];    
                    if (obj != null)
                    {
                        CaCheHelper.SetCache(cacheKey, obj);
                    }
                }
                catch
                {
                }
            }
            return obj.ToString();
        }

        public static bool GetConfigBool(string key)
        {
            bool result = false;
            string configString = ConfigHelper.GetConfigString(key);
            if (configString != null && string.Empty != configString)
            {
                try
                {
                    result = bool.Parse(configString);
                }
                catch (FormatException)
                {
                }
            }
            return result;
        }

        public static decimal GetConfigDecimal(string key)
        {
            decimal result = 0m;
            string configString = ConfigHelper.GetConfigString(key);
            if (configString != null && string.Empty != configString)
            {
                try
                {
                    result = decimal.Parse(configString);
                }
                catch (FormatException)
                {
                }
            }
            return result;
        }
        public static int GetConfigInt(string key)
        {
            int result = 0;
            string configString = ConfigHelper.GetConfigString(key);
            if (configString != null && string.Empty != configString)
            {
                try
                {
                    result = int.Parse(configString);
                }
                catch (FormatException)
                {
                }
            }
            return result;
        }


    }
}

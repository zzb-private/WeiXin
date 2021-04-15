using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ZZB.BLL.Tool
{
    public class HttpClientHelper
    {

        public static T ConvertObject<T>(object asObject) where T : new()
        {
            var serializer = new JavaScriptSerializer();
            //将object对象转换为json字符
            var json = serializer.Serialize(asObject);
            //将json字符转换为实体对象
            var t = serializer.Deserialize<T>(json);
            return t;
        }

        public static async Task<string> PostApi(Uri uri, object data)
        {
            HttpClient client = new HttpClient();
            var str = JsonConvert.SerializeObject(data);

            HttpContent content = new StringContent(str);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await client.PostAsync(uri, content);
            string responseBody = await response.Content.ReadAsStringAsync();

            return responseBody;
        }

        public static async Task<string> GetApi(Uri uri)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(uri);
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }

        public static async Task<string> HttpUploadFile(string url, string fileName, byte[] bArr)
        {
            // 设置参数
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            CookieContainer cookieContainer = new CookieContainer();
            request.CookieContainer = cookieContainer;
            request.AllowAutoRedirect = true;
            request.Method = "POST";
            string boundary = DateTime.Now.Ticks.ToString("X"); // 随机分隔线
            request.ContentType = "multipart/form-data;charset=utf-8;boundary=" + boundary;
            byte[] itemBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "\r\n");
            byte[] endBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");

            //int pos = path.LastIndexOf("\\");
            //string fileName = path.Substring(pos + 1);

            //请求头部信息
            StringBuilder sbHeader =
                new StringBuilder(
                    string.Format(
                        "Content-Disposition:form-data;name=\"media\";filename=\"{0}\"\r\nContent-Type:application/octet-stream\r\n\r\n",
                        fileName));
            byte[] postHeaderBytes = Encoding.UTF8.GetBytes(sbHeader.ToString());
            //FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            //byte[] bArr = new byte[fs.Length];
            //fs.Read(bArr, 0, bArr.Length);
            //fs.Close();

            Stream postStream = request.GetRequestStream();
            postStream.Write(itemBoundaryBytes, 0, itemBoundaryBytes.Length);
            postStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);
            postStream.Write(bArr, 0, bArr.Length);
            postStream.Write(endBoundaryBytes, 0, endBoundaryBytes.Length);
            postStream.Close();

            //发送请求并获取相应回应数据
            HttpWebResponse response = await request.GetResponseAsync() as HttpWebResponse;
            //直到request.GetResponse()程序才开始向目标网页发送Post请求
            Stream instream = response.GetResponseStream();
            StreamReader sr = new StreamReader(instream, Encoding.UTF8);
            //返回结果网页（html）代码
            string content = sr.ReadToEnd();
            return content;
        }
    }
}

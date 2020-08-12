using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WeiXin.Web.Controllers
{
    public class FileController : Controller
    { 
    }
    //{
    //    // GET: File
    //    public ActionResult Index()
    //    {
    //        return View();
    //    }


    //    /// <summary>
    //    /// ajax上传文件
    //    /// </summary>
    //    /// <param name="form">表单其他数据</param>
    //    /// <param name="file"></param>
    //    /// <returns></returns>
    //    [HttpPost]

    //    public async Task<string> upload(FormCollection form, HttpPostedFileBase file)
    //    {
    //        var json = new resultView();

    //        if (null != file)
    //        {
    //            if (string.IsNullOrWhiteSpace(form["title"]))
    //            {
    //                json.isok = false;
    //                json.mess = "请填写文件名";
    //                return Json(json);
    //            }
    //            /**计算指定stream对象的哈希值**/
    //            MD5 hash = new MD5CryptoServiceProvider();
    //            byte[] bytehashValue = hash.ComputeHash(file.InputStream);

    //            var HashCode = BitConverter.ToString(bytehashValue).Replace("-", "");
    //            var hava = true;//_photoGalleryRepository.Existe(HashCode);

    //            var type = file.ContentType.Substring(file.ContentType.IndexOf("/") + 1);
    //            var Photo_name = form["title"];// + "." + file.ContentType.Substring(file.ContentType.IndexOf("/") + 1);
    //                                           //var pathurl = "/UploadFile/" + DateTime.Now.ToString("yyyyMMdd") + "/";//相对路径

    //            var fisize = file.ContentLength;
    //            var filename = file.FileName;
    //            var pathurl = "/UploadFile/UserImg/" + filename;//相对路径

    //            var Mainpath = Server.MapPath("~" + pathurl);
    //            if (file.ContentType == "image/jpg" || file.ContentType == "image/png" || file.ContentType == "image/gif" || file.ContentType == "image/jpeg")
    //            {
    //                if (System.IO.File.Exists(Mainpath + Photo_name))
    //                {
    //                    json.isok = false;
    //                    json.mess = "存在相同文件名，请另起名字";
    //                    return Json(json);
    //                }
    //                if (!Directory.Exists(Mainpath))
    //                {
    //                    Directory.CreateDirectory(Mainpath);
    //                }

    //                if (!hava)
    //                    file.SaveAs(Mainpath + filename);

    //                return Json(json);
    //            }
    //            json.isok = false;
    //            json.mess = "只能上传图片";
    //            return Json(json);
    //        }
    //        json.isok = false;
    //        json.mess = "请先选择图片文件";
    //        return Json(json);
    //    }


    //    /// <summary>
    //    /// 导出excle到指定文件处
    //    /// </summary>
    //    /// <typeparam name="T">数据类型</typeparam>
    //    /// <param name="list">数据集合</param>
    //    /// <param name="dic">字典：key为表头列值,value为对应数据上的属性名称；eg:"名称":"Name"</param>
    //    /// <param name="path">文件夹相对路径</param>
    //    /// <param name="fileName">保存的文件名</param>
    //    /// <returns></returns>
    //    public async Task<string> SaveExcelToFile<T>(IEnumerable<T> list, Dictionary<string, string> dic, string path, string fileName = null) //where T : new()
    //    {
    //        var retpath = "";
    //        await Task.Run(() =>
    //        {
    //            var Ticks = DateTime.Now.Ticks;
    //            fileName = fileName ?? Ticks.ToString();
    //            var mainDir = Server.MapPath("~" + path);
    //            var mainPath = mainDir + "/" + fileName + ".xls";
    //            retpath = path + fileName + ".xls";
    //            //创建表格对象
    //            HSSFWorkbook hssfworkbook = new HSSFWorkbook();
    //            DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
    //            dsi.Company = "NPOI Team";
    //            SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
    //            si.Subject = "NPOI SDK Example";
    //            hssfworkbook.DocumentSummaryInformation = dsi;
    //            hssfworkbook.SummaryInformation = si;

    //            //创建表格单元格
    //            ISheet sheet = hssfworkbook.CreateSheet("Sheet1");
    //            sheet.CreateRow(0);

    //            //添加表头
    //            var h = 0;
    //            foreach (var i in dic)
    //            {
    //                var value = i.Key;
    //                sheet.GetRow(0).CreateCell(h).SetCellValue(value);
    //                h++;
    //                //sheet.GetRow(0).GetCell(a).CellStyle = style;
    //            }

    //            //添加行数据
    //            if (list != null && list.Count() > 0)
    //            {
    //                var row = 1;
    //                Type Ts = list.ElementAt(0).GetType();
    //                foreach (var item in list)
    //                {
    //                    sheet.CreateRow(row);

    //                    var col = 0;
    //                    foreach (var i in dic)
    //                    {
    //                        var value = i.Value;
    //                        var obj = Ts.GetProperty(i.Value);
    //                        var val = "";
    //                        if (obj != null)
    //                        {
    //                            val = obj.GetValue(item, null).ToString();
    //                        }
    //                        //赋值操作
    //                        sheet.GetRow(row).CreateCell(col).SetCellValue(val);
    //                        col++;
    //                    }

    //                    row++;
    //                }
    //            }

    //            //判断文件夹存不存在，不存在新建
    //            if (!Directory.Exists(mainDir))
    //            {
    //                Directory.CreateDirectory(mainDir);
    //            }

    //            FileStream file = new FileStream(mainPath, FileMode.Create);

    //            hssfworkbook.Write(file);
    //            file.Close();
    //            hssfworkbook.Clear();
    //        });
    //        return retpath;
    //    }


    //    public class resultView
    //    {
    //        public bool isok { get; set; } = true;
    //        public string mess { get; set; } = "操作成功";
    //    }
    
}
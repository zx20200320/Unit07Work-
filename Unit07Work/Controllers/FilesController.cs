using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unit07Work.Models;

namespace Unit07Work.Controllers
{
    public class FilesController : Controller
    {
        // GET: Files
        public ActionResult Index()
        {
            string str = "select * from Files";
            List<Files> list = DBHelper<Files>.GetList(str);
            return View(list);
        }
        /// <summary>
        /// 实现文件上传功能
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        [HttpPost]
        public void UpLoad(HttpPostedFileBase fileBase)
        {
            //获得虚拟路径
            string p = "/UpLoad/" + Path.GetFileName(fileBase.FileName);
            //上传文件用物理路径
            fileBase.SaveAs(Server.MapPath(p));            
            int fileSize = fileBase.ContentLength;      //文件的大小
            string sql = $"insert Files values ('{p}',{fileSize})";
             int h=DBHelper<Files>.ExecNonQuery(sql);
            if(h>0)
            {
                Response.Write("<script>alert('上传成功！')</script>");
            }
            else
            {
                Response.Write("<script> alert('上传失败！')</script>");
            }
        }

        /// <summary>
        /// 实现文件下载功能
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        public ActionResult DownLoad(string fileName)
        {
            //获取文件物理路径
            var filePath = Server.MapPath("~/Files");
            var fName = Path.Combine(filePath, fileName);
            return File(fName, "application/*", fileName);
        }
    }
}
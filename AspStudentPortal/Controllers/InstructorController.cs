using AspStudentPortal.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.Mvc;
using AspStudentPortal.Models.MVVC;

namespace AspStudentPortal.Controllers
{
    [Authorize(Roles = "Instructors")]
    public class InstructorController : Controller
    {
        // GET: Instructor
        ApplicationDbContext _db;
        public InstructorController()
        {
            _db = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            return View();
        }

     
        public ActionResult newFile()
        {
           
            List<ObjFile> ObjFiles = new List<ObjFile>();
            foreach (string strfile in Directory.GetFiles(Server.MapPath("~/Files")))
            {
                FileInfo fi = new FileInfo(strfile);
                ObjFile obj = new ObjFile(); 
                obj.File = fi.Name;
                obj.Size = fi.Length;
                obj.Type = GetFileTypeByExtension(fi.Extension);
                 
                ObjFiles.Add(obj);
            
            var coursesdb = _db.courses.ToList();
                SelectList list = new SelectList(coursesdb, "id", "CourseName");
                ViewBag.coursesName = list; 
            }

            return View(ObjFiles);
        }
      

        public FileResult Download(string fileName)
        {
            string fullPath = Path.Combine(Server.MapPath("~/Files"), fileName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);

            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        private string GetFileTypeByExtension(string fileExtension)
        {
            switch (fileExtension.ToLower())
            {
                case ".docx":
                case ".doc":
                    return "Microsoft Word Document";
                case ".xlsx":
                case ".xls":
                    return "Microsoft Excel Document";
                case ".txt":
                    return "Text Document";
                case ".jpg":
                case ".png":
                    return "Image";
                case ".pdf":
                    return "pdf document";
                default:
                    return "Unknown";
            }
        }
        [HttpPost]
        public ActionResult newFile(ObjFile doc)
        {
            if (doc.id == 0)
            {
                foreach (var file in doc.files)
                {

                    if (file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var filePath = Path.Combine(Server.MapPath("~/Files"), fileName);
                        file.SaveAs(filePath);
                        
                    }

                }

                TempData["Message"] = "files uploaded successfully";
               
            }
            _db.objfiles.Add(doc);
            _db.SaveChanges(); 


            return RedirectToAction("newFile");
        }
  

        public ActionResult Courses()
        {
            return View(); 
        }

        public ActionResult Classes()
        {
            return View();
        }

    }
}

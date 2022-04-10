using AspStudentPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspStudentPortal.Controllers
{
    [Authorize(Roles = "Students")]
    public class StudentController : Controller
    {


        ApplicationDbContext _db;
        public StudentController()
        {
            _db = new ApplicationDbContext();
        }

        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
       [AllowAnonymous]
        public ActionResult Profil()
        {
            return View(); 
        }
        public ActionResult StudentEnroll()
        {
            return View(); 
        }
        public ActionResult studentCourses()
        {
            return View(); 
        }
        public ActionResult SchoolBranch()
        {
            return View(); 
        }


        /******************************/
       public ActionResult NewRequest()
        {
            var demand = new Demand();
            return View(demand);
        }
        [HttpPost]
        public ActionResult NewRequest(Demand request)
        {
            if (request.id == 0)
            {
                _db.demands.Add(request);
                _db.SaveChanges();

            }

            return RedirectToAction("List_Request", "Student");
        }
      
        public ActionResult Delete_Request(int id)
        {
            var demand = _db.demands.Single(c => c.id == id);
            _db.demands.Remove(demand);
            _db.SaveChanges();

            return RedirectToAction("List_Request");
        }

        public ActionResult List_request()
        {
            var demands= _db.demands.ToList();
            return View(demands);
        }

    }
}
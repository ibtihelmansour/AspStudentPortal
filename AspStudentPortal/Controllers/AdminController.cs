using AspStudentPortal.Models;
using AspStudentPortal.Models.MVVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspStudentPortal.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        ApplicationDbContext _db;

        public AdminController()
        {
            _db = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult NewEnrollment()
        {
            var studentdb = _db.students.ToList();
            var classDb = _db.classes.ToList(); 
            var enrollmentStudent = new EnrollmentStudent
            {
                Students = studentdb,
                Classes = classDb , 
            };
            return View(enrollmentStudent);
        }

        [HttpPost]
        public ActionResult CreateEnrollment(Enrollment enrollment)
        {
            if (enrollment.id == 0)
            {
                _db.enrollments.Add(enrollment);
                

            }
            /* else
             {
                 var enrollmentDb = _db.enrollments.Single(c => c.id == enrollment.id);
                 enrollmentDb.classe.nameClasse = enrollment.classe.nameClasse;
                 enrollmentDb.dateEnrollment = enrollment.dateEnrollment;
                 enrollmentDb.student.UserName = enrollment.student.UserName;
             }*/
            _db.SaveChanges();

            return RedirectToAction("Index", "Admin");

        }


    }
}
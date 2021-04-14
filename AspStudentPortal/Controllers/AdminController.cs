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

            return RedirectToAction("ListEnrollment", "Admin");
        }

        public  ActionResult ListStudent()
        {
            var students = _db.students.ToList();
            return View(students); 
        }

        public ActionResult ListInstructor()
        {
            var instructors = _db.instructors.ToList();
            return View(instructors);
        }
        public ActionResult ListAdmin()
        {
            var admins = _db.admins.ToList();
            return View(admins);
        }
        public ActionResult ListEnrollment()
        {
            var enrollments = _db.enrollments.ToList();
            return View(enrollments);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            var User = _db.Users.SingleOrDefault(c => c.Id.Equals(id));
           
            return View("Register" , "Account" , User);

        }

      /*  public ActionResult EditForm(ApplicationUser model)
        {
            var user = _db.Users.Single(c => c.Id == model.Id);
            user.UserName = model.UserName;
            user.dateOfbirth = model.dateOfbirth;
            user.Email = model.Email;
            user.gender = model.gender;
            user.address = model.address;
            user.PhoneNumber = model.PhoneNumber;
            _db.SaveChanges();
            return RedirectToAction("Index", "Admin");

        }
       */
    


}
}
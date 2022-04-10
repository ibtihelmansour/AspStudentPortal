using AspStudentPortal.Models;
using AspStudentPortal.Models.MVVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspStudentPortal.Controllers
{
    [Authorize(Roles ="Admins")]
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
  /*********************** enrollment *********************/
        public ActionResult NewEnrollment()
        {
            var studentdb = _db.students.ToList();
            var Classdb = _db.classes.ToList(); 
            var enrollmentStudent = new EnrollmentStudent
            {
                Students = studentdb,
                classes = Classdb 
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
             else
             {
                 var enrollmentDb = _db.enrollments.Single(c => c.id == enrollment.id);
                 enrollmentDb.ClasseId = enrollment.ClasseId;
                 enrollmentDb.dateEnrollment = enrollment.dateEnrollment;
                 enrollmentDb.studentId = enrollment.studentId;
             }
            _db.SaveChanges();

            return RedirectToAction("ListEnrollment", "Admin");
        }
        [HttpGet]
        public ActionResult EditEnrollment(int id)
        {

            var enrollment = _db.enrollments.SingleOrDefault(c => c.id == id);
            var viewModel = new EnrollmentStudent
            {
                enrollment = enrollment,
                classes = _db.classes.ToList(),
                Students= _db.students.ToList()
            };
            return View("NewEnrollment", viewModel);

        }
        public ActionResult DeleteEnrollment(int id)
        {
            var enrollment = _db.enrollments.Single(c => c.id==id);
            _db.enrollments.Remove(enrollment);
            _db.SaveChanges();

            return RedirectToAction("ListEnrollment");
        }

        public ActionResult ListEnrollment()
        {
            var enrollments = _db.enrollments.ToList();
            return View(enrollments);
        }
        /***************************** classe ***********************************/

        public ActionResult NewClasse()
        {
            var branchdb = _db.schoolBranches.ToList();
          
            var classBranchmvvc = new ClassBranchmvvc
            {
               
                schoolBranches = branchdb
            };
            return View(classBranchmvvc);
        }

        [HttpPost]
        public ActionResult CreateClasse(Classe classe)
        {
            if (classe.id == 0)
            {
                _db.classes.Add(classe);
            }
            else
            {
                var classeDb = _db.classes.Single(c => c.id == classe.id);
                classeDb.schoolBranchId = classe.schoolBranchId;
                classeDb.nameClasse = classe.nameClasse; 
              
            }
                _db.SaveChanges();

                return RedirectToAction("ListClasse", "Admin");
            }
        public ActionResult ListClasse()
        {
            var classes = _db.classes.ToList();
            

            return View(classes);
        }
        public ActionResult DeleteClasse(int id)
        {
            var classe = _db.classes.Single(c => c.id == id);
            _db.classes.Remove(classe);
            _db.SaveChanges();

            return RedirectToAction("ListClasse");
        }
        [HttpGet]
        public ActionResult EditClasse(int id)
        {

            var classe = _db.classes.SingleOrDefault(c => c.id == id);
            var viewModel = new ClassBranchmvvc
            {
                classe = classe,
                schoolBranches= _db.schoolBranches.ToList(),
               
            };
            return View("NewClasse", viewModel);

        }


        /***************************************BranchSchool*************************************/
        public ActionResult NewSchoolBranch()
        {
            var schoolbranch= new SchoolBranch();
           
            return View(schoolbranch);
        }

        [HttpPost]
        public ActionResult CreateSchoolBranch(SchoolBranch schoolbranchdb)
        {
            if (schoolbranchdb.id == 0)
            {
                _db.schoolBranches.Add(schoolbranchdb);
            }
            else
            {
                var schoolBranch = _db.schoolBranches.Single(c => c.id == schoolbranchdb.id);
                schoolBranch.name = schoolbranchdb.name;
                schoolBranch.level = schoolbranchdb.level; 
              
            }
            _db.SaveChanges();

            return RedirectToAction("ListSchoolBranch", "Admin");
        }
        [HttpGet]
        public ActionResult EditSchoolBranch(int id)
        {

            var schoolBranch = _db.schoolBranches.SingleOrDefault(c => c.id == id);
            var viewModel = new SchoolBranch(); 
            
            
            return View("NewSchoolBranch", viewModel);

        }
        public ActionResult DeleteSchoolBranch(int id)
        {
            var schoolBranch = _db.schoolBranches.Single(c => c.id == id);
            _db.schoolBranches.Remove(schoolBranch);
            _db.SaveChanges();

            return RedirectToAction("ListSchoolBranch");
        }

        public ActionResult ListSchoolBranch()
        {
            var schoolBranchs = _db.schoolBranches.ToList();
            //  classe = _db.classes.SingleOrDefault(); 
          
            return View(schoolBranchs);
        }

        /*******************************  courses  ****************************************/
          public ActionResult NewCourse()
        {
         
            var schoolbranchs = _db.schoolBranches.ToList();
            var instructors = _db.instructors.ToList();

            var courseInstructorMvvc = new CourseInstructorMvvc
            {
                schoolBranches = schoolbranchs  , 
                instructors = instructors 
            };
            return View(courseInstructorMvvc);
        }

        [HttpPost]
        public ActionResult CreateCourse(Course course)
        {
            if (course.id == 0)
            {
                _db.courses.Add(course);
            }
            else
            {
                var courseDb = _db.courses.Single(c => c.id == course.id);
                courseDb.CourseName = course.CourseName;
                courseDb.coef = course.coef;
                courseDb.instructor = course.instructor;
                courseDb.schoolBranch = course.schoolBranch; 

            }
            _db.SaveChanges();

            return RedirectToAction("ListCourse", "Admin");
        }
        public ActionResult ListCourse()
        {
            var courses = _db.courses.ToList();
            return View(courses);
        }
        public ActionResult DeleteCourse(int id)
        {
            var course = _db.courses.Single(c => c.id == id);
            _db.courses.Remove(course);
            _db.SaveChanges();

            return RedirectToAction("ListCourse");
        }
        [HttpGet]
        public ActionResult EditCourse(int id)
        {

            var course = _db.courses.SingleOrDefault(c => c.id == id);
            var viewModel = new CourseInstructorMvvc
            {
                course = course,
                schoolBranches = _db.schoolBranches.ToList(),
                instructors = _db.instructors.ToList() 
            };
            return View("NewCourse", viewModel);

        }
        /**********************************/
        public ActionResult ListStudent()
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
      

        public ActionResult DeleteUser(string idUser)
        {
            var user = _db.Users.Single(c => c.Id.Equals(idUser));
            _db.Users.Remove(user);
            _db.SaveChanges();
           
            return RedirectToAction("Index", "Admin");
        }

        public ActionResult BranchSchoolByCourses (int id )
        {
            var branchs = _db.schoolBranches.SingleOrDefault(c => c.id == id);
            return View(branchs); 
        }

      



    }
}
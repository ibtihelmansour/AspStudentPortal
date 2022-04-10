using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspStudentPortal.Models.MVVC
{
    public class CourseInstructorMvvc
    {
        public Course course { get; set;  }
        public IEnumerable<SchoolBranch> schoolBranches { get; set; }
        public IEnumerable<Instructor> instructors { get; set;  }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspStudentPortal.Models
{
    public class Course
    {

        public int id { get; set;  }
        public string  CourseName { get; set;  }
        public int coef { get; set; }
        public SchoolBranch schoolBranch { get; set;  }
        public int SchoolBranchId { get; set;  }
        public Instructor instructor { get; set;  }
        public string instructorId { get; set;  }

        // public virtual ICollection<Course> courses { get; set; }
        public virtual ICollection<ObjFile> objFiles { get; set; }

    }
}
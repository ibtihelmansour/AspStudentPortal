using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspStudentPortal.Models
{
    public class Instructor : ApplicationUser
    {
       // public float salary { get; set;  }
       public virtual ICollection<Course> courses { get; set;  }
    }
}
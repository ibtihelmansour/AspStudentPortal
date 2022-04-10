using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspStudentPortal.Models.MVVC
{
    public class DocumentCourse
    {
        public ObjFile objFile { get; set;  }
        public IEnumerable<Course> courses { get; set; }
       // public IEnumerable<Classes> classes { get; set; }
    }
}
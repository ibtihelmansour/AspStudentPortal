using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspStudentPortal.Models.MVVC
{
    public class EnrollmentStudent
    {
        public Enrollment enrollment { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<Classe> Classes { get; set; }

    }
}
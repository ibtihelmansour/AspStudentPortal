using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspStudentPortal.Models
{
    public class Classe
    {
        public int id { get; set; }
        public string nameClasse { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspStudentPortal.Models
{

    public class Enrollment
    {



        public int id { get; set; }

        public paymentMethod? paymentMethod { get; set; }
        [Display(Name ="date of Enrollment")]
        public DateTime? dateEnrollment { get; set; }

        //public int StudentId { get; set; }
        public int ClasseId { get; set; }
        public string studentId { get; set;  }
       public virtual  Student student { get; set; }
       public virtual Classe classe { get; set; }

    }

    public enum paymentMethod
    {
        M1, M2, M3, Alternance
    }


}
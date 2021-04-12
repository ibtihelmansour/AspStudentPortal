using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspStudentPortal.Models
{
    public class Student : ApplicationUser
    {
        
        public DateTime? dateOfbirth { get; set;  }
        public string address { get; set;  }
    }


  
}
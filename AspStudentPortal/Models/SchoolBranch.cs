using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspStudentPortal.Models
{
    public class SchoolBranch
    {
       
      //  public string idBranch { get { return idBranch; } set { idBranch = name + "-" + level; } }
        public int id { get; set;  }
       public string name { get; set;  }
       public int level { get; set;  }

        public virtual ICollection<Classe> classes { get; set; }
        public virtual ICollection<Course> courses { get; set; }


    

    }


   
}
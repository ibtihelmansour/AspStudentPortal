using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspStudentPortal.Models
{
    public class Document
    {
        
        public int id { get; set;  }
        public IEnumerable<HttpPostedFileBase> files { get; set; }
        public long Size { get; set;  }
        public string Type { get; set;  }
        public string File { get; set; }
        public virtual ICollection<Classes> classes { get; set;  }
        public Course course { get; set;  }
        public int courseId { get; set;}
    }
}
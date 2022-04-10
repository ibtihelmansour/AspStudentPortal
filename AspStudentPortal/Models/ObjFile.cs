using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspStudentPortal.Models
{
    public class ObjFile
    {
        [Key]
        public int id { get; set;  }
        public IEnumerable<HttpPostedFileBase> files { get; set; }
        public string File { get; set; }
        public long Size { get; set; }
        public string Type { get; set; }
        public Course course { get; set;  }
        public int courseId { get; set;  }
    
    }
}
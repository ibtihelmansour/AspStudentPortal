using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspStudentPortal.Models.MVVC
{
    public class ClassBranchmvvc
    {
        public Classe classe { get; set; }
        public IEnumerable<SchoolBranch> schoolBranches { get; set; }
    }
}
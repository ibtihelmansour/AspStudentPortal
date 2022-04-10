using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspStudentPortal.Models
{
    public class Demand
    {
        public int id { get; set; }
        public Subject? subject{ get ; set ; } 
        public string description { get; set; }

    }

    public enum Subject {
        diploma , certificate , whiteTest , voucher , 
    }
}
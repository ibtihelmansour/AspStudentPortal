using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspStudentPortal.Models
{
    public class paymentMethod
    {
        [Key]
        public string MethodName { get; set;  }
        public float yearFees { get; set;  }
        public float RegistrationFees { get; set;  }
        public float partwithMarkup { get; set;  }
        public float partWithoutMarkup { get; set;  }
        public float markupPercent { get; set;  }
        public string collegeYear { get; set;  }
       /* public paymentMethod()
        {

            partwithMarkup = markupPercent * (yearFees - partWithoutMarkup); 

        }
        public float getpartwithmarkup ( )
        {
            partwithMarkup = partwithMarkup+ (markupPercent * (yearFees - partWithoutMarkup));
            return partwithMarkup; 
        }*/

    }

    
}
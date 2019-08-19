using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Payroll1.Models
{
    public class UploadFile
    {
      

        public string _date{ get; set; }
        public string _empID { get; set; }
        public string HoursWorked { get; set; }
        public string  JobGroup { get; set; }

    }
}
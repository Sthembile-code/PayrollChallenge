using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Payroll1.Models
{
    public class Salary
    {
        [Display(Name ="Employee ID")]
        [Required(ErrorMessage ="Employee ID is requied")]
        [Range(1,100,ErrorMessage ="Please Enter between 1 and 100")]
        public int EmpId { get; set; }

        [Display(Name = "Hours Worked")]
        [Required(ErrorMessage = "Please Enter Hours Worked")]
        [Range(1, 100, ErrorMessage = "Please Enter between 1 and 100")]
        public double hours { get; set; }

        public double rateA = 20;
        public double rateB = 30;

        [Display(Name ="Amount Paid")]
        public double AmountPaid{ get; set; }
        public double CalcSal { get; set; }

        [Required(ErrorMessage ="Please select pay period")]
        [Display(Name ="Pay Period")]
        public DateTime PayPeriod { get; set; }
    }
}
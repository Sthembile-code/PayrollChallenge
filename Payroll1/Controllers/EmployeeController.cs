using Payroll1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Payroll1.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View(new Salary());
        }

        //Calculate amount paid based on Employee ID entered by user
        [HttpPost]
        public ActionResult Index(Salary s)
        { 
               if (s.EmpId == 1)
                {
                    s.CalcSal = s.hours * s.rateA;
                    s.AmountPaid = s.CalcSal;
                }
                else if (s.EmpId == 2)
                {
                    s.CalcSal = s.hours * s.rateB;
                    s.AmountPaid = s.CalcSal;
                }

                return View(s);
        }
    }
}
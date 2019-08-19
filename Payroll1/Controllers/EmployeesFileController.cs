using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Web.Mvc;
using Payroll1.Models;
using Excel = Microsoft.Office.Interop.Excel;


namespace Payroll1.Controllers
{
    public class EmployeesFileController : Controller
    {
        // GET: EmployeesFile
        public ActionResult UploadEmployess()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Import(HttpPostedFileBase excelfile)
        {
            if(excelfile == null || excelfile.ContentLength == 0)
            {
                ViewBag.Error = "Please select a excel file <br>";
                return View("UploadEmployess");
            }
            else
            {
                if(excelfile.FileName.EndsWith("xls") || excelfile.FileName.EndsWith("xlsx"))
                {
                    string path = Server.MapPath("~/Content/" + excelfile.FileName);
                    if (System.IO.File.Exists(path))
                        System.IO.File.Delete(path);
                    excelfile.SaveAs(path);
                    //read data from Excel file
                    Excel.Application application = new Excel.Application();
                    Excel.Workbook workbook = application.Workbooks.Open(path);
                    Excel.Worksheet worksheet = workbook.ActiveSheet;
                    Excel.Range range = worksheet.UsedRange;
                    List<UploadFile> listEmployees = new List<UploadFile>();
                    for(int row = 2; row < range.Rows.Count; row++)
                    {
                        // UploadFile emp = new UploadFile();  
                        UploadFile emp = new UploadFile
                        {
                            _date = ((Excel.Range)range.Cells[row, 1]).Text,
                            HoursWorked = ((Excel.Range)range.Cells[row, 2]).Text,
                            _empID = ((Excel.Range)range.Cells[row, 3]).Text,
                            JobGroup = ((Excel.Range)range.Cells[row, 4]).Text
                        };
                        listEmployees.Add(emp);
                    }
                    ViewBag.ListEmployees = listEmployees;
                    return View("Success");
                }
                else
                {
                    ViewBag.Error = "File type is incorrect";
                    return View("UploadEmployess");
                }
              
            }
           
        }

    }
}
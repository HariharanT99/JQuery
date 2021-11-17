using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Models;

namespace Test.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public static bool SaveEmp(Employee emp)
        {
            try
            {
                // Implement your logic to save EmpList in Database  
            }
            catch (Exception ex)
            {
                // Log Error  
                return false;
            }

            return true;
        }
    }
}
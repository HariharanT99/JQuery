using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Test.Models;
using System.Web.Script.Serialization;

namespace Test.Controllers
{
    public class StudentController : Controller
    {
        //List<Student> students = new List<Student>{
        //    new Student { StudentId = 1, StudentName= "Student1", Age = 22},
        //    new Student { StudentId = 2, StudentName= "Student2", Age = 22},
        //    new Student { StudentId = 3, StudentName= "Student3", Age = 22},
        //    new Student { StudentId = 4, StudentName= "Student4", Age = 22},
        //    new Student { StudentId = 5, StudentName= "Student5", Age = 22},
        //    new Student { StudentId = 6, StudentName= "Student6", Age = 22},
        //    new Student { StudentId = 7, StudentName= "Student7", Age = 22},
        //    new Student { StudentId = 8, StudentName= "Student8", Age = 22},
        //    new Student { StudentId = 9, StudentName= "Student9", Age = 22},
        //    new Student { StudentId = 10, StudentName= "Student", Age = 22}

        //};

        StudentModel _db = new StudentModel();

        // GET: Student
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllStudents()
        {
            List<Student> students = _db.Students.ToList();

            return Json(students, JsonRequestBehavior.AllowGet);
        }

        [NonAction]
        public string GetJsonList(List<Student> students)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();

            string studentJson = js.Serialize(students);

            return studentJson;
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Student/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Student std)
        {
            try
            {
                _db.Students.Add(std);
                _db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //Get student by id
        public void GetStudent(int id)
        {
            Student student = _db.Students.Find(id);

            string studentJson = GetJson(student);

            Response.Write(studentJson);
        }

        //Convert to Json
        [NonAction]
        private string GetJson(Student std)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();

            string studentJson = js.Serialize(std);

            return studentJson;
        }


        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Id = id;

            return View();
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            try
            {
                Student std = _db.Students.Find(student.Id);
                std.Name = student.Name;
                std.Age = student.Age;
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

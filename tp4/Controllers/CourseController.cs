using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Web.Mvc;
using tp4.Data;
using tp4.Models;

namespace tp4.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {


            UniversityContext universityContext = UniversityContext.Instantiate_UniversityContext();
            StudentRepository studentRepository = new StudentRepository(universityContext);
            foreach (String s in studentRepository.GetCourses())
                Debug.WriteLine(s);

            return (IActionResult)View(studentRepository.GetCourses());
        }

        public IActionResult GetCourse(string id)
        {
            UniversityContext universityContext = UniversityContext.Instantiate_UniversityContext();
            StudentRepository studentRepository = new StudentRepository(universityContext);
            IEnumerable<Student> res = (IEnumerable<Student>)studentRepository.Find(v => v.course.ToLower() == id.ToLower());
            foreach (Student s in res)
            {
                Debug.WriteLine(s.id);
            } 

            if (res.Count() != 0) ViewBag.Id = res.First().course;
            return (IActionResult)View( res);
        }
    }
}

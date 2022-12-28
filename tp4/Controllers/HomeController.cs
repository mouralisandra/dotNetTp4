using Abp.Web.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using tp4.Data;
using tp4.Models;
using Microsoft.EntityFrameworkCore.Query;
namespace tp4.Controllers
{
    public class HomeController : Controller
    {


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            UniversityContext universityContext = UniversityContext.Instantiate_UniversityContext();
            Debug.WriteLine("UniversityContext is instantiated {0} times", UniversityContext.count);
            List<Student> s = universityContext.Student.ToList();
            foreach (Student student in s)
            {
                Debug.WriteLine("Student {0} {1} {2} {3}  ", student.id, student.first_name, student.last_name, student.phone_number);
            }
            return (IActionResult)View();
        }

        public IActionResult Privacy(string id)
        {

            return (IActionResult)View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return (IActionResult)View(model: new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
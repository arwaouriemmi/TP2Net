using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using WebApplication7.Data;
using WebApplication7.Models;
using static System.Net.Mime.MediaTypeNames;

namespace WebApplication7.Controllers
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
            UniversityContext i1 = UniversityContext.Instance();
            UniversityContext i2 = UniversityContext.Instance();
            List<Student> s = i1.Student.ToList();
            foreach(Student student in s)
            {
                Debug.WriteLine("id =" + student.id + " first_name:" + student.first_name + " last_name :" + student.last_name +  " university :" + student.university + " course :" + student.course);
            }
            
            return View();
        }
        public IActionResult Courses()
        {
            UniversityContext i1 = UniversityContext.Instance();
            StudentRepository s = new StudentRepository(i1);
            IEnumerable<string> liste = s.CoursesUniques();
            return View(liste);
        }
        public IActionResult StudentsbyCourse(string x)
        {
            UniversityContext i1 = UniversityContext.Instance();
            StudentRepository s = new StudentRepository(i1);
            
            IEnumerable<Student> liste = s.StudentsbyCourse(x);
            
            return View(liste);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
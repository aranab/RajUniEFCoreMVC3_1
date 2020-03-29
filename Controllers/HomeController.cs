using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RajUniEFCoreMVC3_1.Data;
using RajUniEFCoreMVC3_1.Models;
using RajUniEFCoreMVC3_1.Models.SchoolViewModels;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RajUniEFCoreMVC3_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly SchoolContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(SchoolContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> About()
        {
            IQueryable<EnrollmentDateGroup> data = from student in _context.Students 
                                                   group student by student.EnrollmentDate into dateGroup 
                                                   select new EnrollmentDateGroup() 
                                                   { 
                                                       EnrollmentDate = dateGroup.Key, 
                                                       StudentCount = dateGroup.Count()
                                                   };
            
            return View(await data.AsNoTracking().ToListAsync());
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

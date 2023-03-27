using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection.Metadata;
using ZeroHunger.Database.Entity;
using ZeroHunger.Model;
using ZeroHunger.Web.Models;

namespace ZeroHunger.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext db;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext _db)
        {
            _logger = logger;
            db = _db;
        }

        public IActionResult Index()
        {
            IEnumerable<Request> obj = db.Requests;
            obj = obj.Where(u => u.Status == null);
            return View(obj);
        }
        public IActionResult Details(int Id)
        {
            string rarea = db.Requests.Select(u => u.Restaurant.Area).FirstOrDefault().ToString();       
            IEnumerable<Employee> employees = db.Employees.Where(u=>u.Address== rarea);
            IEnumerable<SelectListItem> emp = employees.Select(
                u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                }
                );
            ViewBag.Emp=emp;
            var Obj = db.Requests.FirstOrDefault(u => u.Id==Id);
            return View(Obj);
            //return Json(employees);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(Request request)
        {
            var r = db.Requests.FirstOrDefault(u=>u.Id==request.Id);
            if(r!=null)
            {
                r.EmployeeId = request.EmployeeId;
                r.Status= request.Status;
                db.Requests.Update(r);
                db.SaveChanges();
                return RedirectToAction("Index");

            }                        
            return View(request);
           
           

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
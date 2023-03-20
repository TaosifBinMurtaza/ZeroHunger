using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using ZeroHunger.Database.Entity;
using ZeroHunger.Model;

namespace ZeroHunger.Web.Areas.Restaurant.Controllers
{
    [Area("Restaurant")]
    public class RestaurantController : Controller
	{
        private readonly ApplicationDbContext db;
        public RestaurantController(ApplicationDbContext _db)
        {
            db=_db;
        }

      
		public IActionResult Index()
		{
            IEnumerable<Request> obj = db.Requests;
            obj = obj.Where(u=>u.RestaurantId==1);
            obj = obj.Where(u => u.Status == null);
            return View(obj);
		}
        public IActionResult Request()
        {
            
            //IQueryable<Request> obj = db.Requests.Include(u => u.Restaurant);       
            return View();
            //return Json(obj);
        }
        [HttpPost]
        public IActionResult Request(Request obj)
        {
            if(ModelState.IsValid)
            {
                db.Requests.Add(obj);
                db.SaveChanges();
                return RedirectToAction("Index");               
               
            }
            return View(obj);

        }
    }
}

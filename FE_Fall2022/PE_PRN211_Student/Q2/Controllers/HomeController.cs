using Microsoft.AspNetCore.Mvc;
using Q2.Models;
namespace Q2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            using (PE_PRN_Fall22B1Context context = new PE_PRN_Fall22B1Context())
            {
                ViewBag.Direc = context.Directors.ToList();
                var gen = context.Genres.ToList();
                var direc = context.Directors.ToList();
                var pro = context.Producers.ToList();

                ViewBag.Mov = context.Movies.ToList();
                return View();
            }
        }


            public IActionResult Search(int id)
            {
                using (PE_PRN_Fall22B1Context context = new PE_PRN_Fall22B1Context())
                {
                    ViewBag.Direc = context.Directors.ToList();
                    var gen = context.Genres.ToList();
                    var direc = context.Directors.ToList();
                    var pro = context.Producers.ToList();

                    ViewBag.Mov = context.Movies.Where(p=>p.DirectorId==id).ToList();
                    return View("Index");
                }
            }

        }
}

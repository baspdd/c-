using Microsoft.AspNetCore.Mvc;
using PT2.Models;

namespace PT2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            using (PRN292_SU17_1Context context = new PRN292_SU17_1Context())
            {
                ViewBag.Details = context.DummyDetails.ToList();
                ViewBag.Masters = context.DummyMasters.ToList();
                return View();

            }
               
        }
        [HttpPost]
        public IActionResult Index(int Mid, string txt)
        {
            using (PRN292_SU17_1Context context = new PRN292_SU17_1Context())
            {
                if (txt!=null)
                {
                    txt = txt.ToUpper();
                    if (Mid !=0)
                    {
                        ViewBag.MSG = txt;
                        ViewBag.Selected = Mid;
                        ViewBag.Details = context.DummyDetails.Where(p => p.DetailName.Contains(txt) && p.Master.MasterId == Mid).ToList();
                        ViewBag.Masters = context.DummyMasters.ToList();
                    }
                    else
                    {
                        ViewBag.MSG = txt;
                        ViewBag.Selected = Mid;
                        ViewBag.Details = context.DummyDetails.Where(p => p.DetailName.Contains(txt)).ToList();
                        ViewBag.Masters = context.DummyMasters.ToList();
                    }
                }
                else
                {
                    if (Mid != 0)
                    {
                        ViewBag.MSG = "";
                        ViewBag.Selected = Mid;
                        ViewBag.Details = context.DummyDetails.Where(p => p.Master.MasterId == Mid).ToList();
                        ViewBag.Masters = context.DummyMasters.ToList();
                    }
                    else
                    {
                        ViewBag.MSG = "";
                        ViewBag.Selected = Mid;
                        ViewBag.Details = context.DummyDetails.ToList();
                        ViewBag.Masters = context.DummyMasters.ToList();
                    }
                }
               
                return View();
            }
        }
    }
}

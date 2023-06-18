using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PE_Trial.Models;
using System.Diagnostics;
using System.Text.Json.Nodes;

namespace PE_Trial.Pages
{
    public class ListModel : PageModel
    {
        public void OnGet()
        {
            try
            {
                using (var db = new PRN221_TrialContext())
                {
                    List<Service> services = db.Services.
                        Include(service => service.EmployeeNavigation)
                        .Where(service => service.Month == 3)
                        .ToList();

                    ViewData["services"] = services;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [BindProperty]
        public string Name1 { get; set; }

        public void OnPost()
        {
            Console.WriteLine(Name1);

            show();
        }

        private void show()
        {
            try
            {
                using (var db = new PRN221_TrialContext())
                {
                    List<Service> services = db.Services.
                        Include(service => service.EmployeeNavigation)
                        .Where(service => service.Month == 3)
                        .ToList();

                    ViewData["services"] = services;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [BindProperty]
        public string ID { get; set; }

        [HttpPost]
        public void OnDelete()
        {

            Console.WriteLine("come here");
            try
            {
                using (var db = new PRN221_TrialContext())
                {
                    Service service = db.Services.FirstOrDefault(s => s.Id == Int32.Parse(ID));
                    Console.WriteLine(ID);
                    db.Services.Remove(service);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }


            show();
        }

    }
}

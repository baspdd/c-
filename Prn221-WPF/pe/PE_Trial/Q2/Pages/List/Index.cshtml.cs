using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Q2.Models;
using System.Text.Json;

namespace Q2.Pages.List
{
    public class IndexModel : PageModel
    {
        private readonly PRN221_Spr22Context context;
        public string Room { get; set; }
        public List<Service> Services { get; set; } = new List<Service>();

        public IndexModel(PRN221_Spr22Context context)
        {
            this.context = context;
        }

        public void OnGet(string room)
        {
            Room = room;
            if (string.IsNullOrEmpty(Room))
            {
                var currentMonth = DateTime.Now.Month;
                Services = context.Services.Include(s => s.EmployeeNavigation).ToList();
            }
            else
            {
                Services = context.Services.Include(s => s.EmployeeNavigation).Where(s => s.RoomTitle.Contains(Room)).ToList();
            }
        }

        public void OnPost(IFormFile inpFile)
        {
            string fileContent = string.Empty;
            using (var reader = new StreamReader(inpFile.OpenReadStream()))
            {
                fileContent = reader.ReadToEnd();
            }
            if (!String.IsNullOrEmpty(fileContent))
            {
                var list = JsonSerializer.Deserialize<List<Models.Service>>(fileContent);
                if (list.Count > 0)
                {
                    foreach (var item in list)
                    {
                        item.Id = 0;
                    }
                    context.Services.AddRange(list);
                    context.SaveChanges();
                }
                Services = context.Services.Include(s => s.EmployeeNavigation).ToList();
            }
        }
    }
}

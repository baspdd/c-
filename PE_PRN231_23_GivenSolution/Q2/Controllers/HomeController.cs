using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Q2.Models;
using WebMVC.Models;

namespace web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var client = new HttpClient();

                var response = await client.GetAsync("http://localhost:5270/api/Questions?filter=keyId eq 'MAE101_FA23'");
                var data = await response.Content.ReadAsStringAsync();
                var check = System.Text.Json.JsonSerializer.Deserialize<List<Question>>(data);

                client.Dispose();

                return View();
            }
            catch (Exception e)
            {
                throw;
            }
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
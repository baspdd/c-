using Asm2_web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Xml.Linq;

namespace Asm2_web.Controllers
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
            return View();
        }

        string urlUser = "http://localhost:5102/api/User";
        [HttpPost]
        public async Task<IActionResult> LoginAsync(string user, string pass)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(urlUser + "/user?email=" + user + "&password=" + pass);
            var data = await response.Content.ReadAsStringAsync();
            var acc = System.Text.Json.JsonSerializer.Deserialize<User>(data);
            client.Dispose();
            if (acc != null) return RedirectToAction("Author");
            return View("Index");
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUpAsync(string user, string pass, string repass)
        {
            if (pass != repass) return View();

            User pro = new User
            {
                email = user,
                password = pass,
                roleId = 1,
                pubId = 1,
            };
            var client = new HttpClient();
            var response = await client.PostAsJsonAsync(urlUser, pro);
            var check = response.IsSuccessStatusCode;
            client.Dispose();
            if (check) return RedirectToAction("Index");
            return View("SignUp");

        }
        public async Task<IActionResult> AuthorAsync()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(urlUser);
            var data = await response.Content.ReadAsStringAsync();
            var acc = System.Text.Json.JsonSerializer.Deserialize<User>(data);
            client.Dispose();
            if (acc != null) return RedirectToAction("Author");
            return View();
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
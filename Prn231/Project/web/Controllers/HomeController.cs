using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Diagnostics;
using web.iAPI;
using web.Models;

namespace web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        private string url = "http://localhost:5024/api";

        public async Task<IActionResult> IndexAsync()
        {
            List<Question> ques = new List<Question>();
            var questApi = RestService.For<IQuestionsAPI>(url);
            ques = await questApi.GetQuestions("MAE101_FA23");
            return View();
        }

        public IActionResult Login()
        {

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
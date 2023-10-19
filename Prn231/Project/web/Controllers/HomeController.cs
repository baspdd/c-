using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging;
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

        public async Task<IActionResult> IndexAsync(string? key = "MAE101_FA23")
        {
            //if (key == null) return RedirectToAction("Login");
            var questApi = RestService.For<IQuestionsAPI>(url);
            var ques = await questApi.GetQuestions(key);
            foreach (Question item in ques)
            {
                item.listAnswer.AddRange(item.GetAnswers(item.Answer));
                item.numberRightAnswer = item.GetNumberAnswers(item.RightAnswer);
            }

            return View(ques);
        }

        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> Login(Account? account, string? key)
        {
            if (account.AccountId == null || key == null) return View();
            var accApi = RestService.For<IAccountAPI>(url);
            var accounts = await accApi.GetAcc(account.AccountId, account.Password);
            var quesAPi = RestService.For<IQuestionsAPI>(url);
            var check = await quesAPi.CheckKey(key);
            if (accounts.Count == 0 || !check) return View();

            return RedirectToAction("Index", new { key = key });
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
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Linq;
using WebMVC.Models;
using static System.Net.WebRequestMethods;

namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        string url = "http://localhost:5205/api/Values";
        public async Task<IActionResult> IndexAsync(string? name, string? master)
        {
            var client = new HttpClient();
            var response1 = await client.GetAsync(url + "/master");
            var data1 = await response1.Content.ReadAsStringAsync();
            ViewBag.Categories = System.Text.Json.JsonSerializer.Deserialize<List<DummyMaster>>(data1);
            if (name == null && master == "----All----" || master == null)
            {
                var response2 = await client.GetAsync(url);
                var data2 = await response2.Content.ReadAsStringAsync();
                ViewBag.ListP = System.Text.Json.JsonSerializer.Deserialize<List<DummyDetail>>(data2);
                return View();
            }
            List<DummyDetail> list1 = await getListAsync(client, url + "/list?name=" + master);
            List<DummyDetail> list2 = await getListAsync(client, url + "/detail?name=" + name);

            list1.AddRange(list2);
            ViewBag.ListP = list1.Distinct().ToList();
            client.Dispose();
            return View();

        }

        private async Task<List<DummyDetail>> getListAsync(HttpClient client, string url)
        {
            List<DummyDetail> list = new List<DummyDetail>();
            var response = await client.GetAsync(url);
            if (!response.IsSuccessStatusCode) { return list; }
            var data = await response.Content.ReadAsStringAsync();
            list = System.Text.Json.JsonSerializer.Deserialize<List<DummyDetail>>(data);
            return list;
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
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        string url = "http://localhost:5110/api/Category";
        string urlProduct = "http://localhost:5110/api/Product";
        public async Task<IActionResult> IndexAsync()
        {
            try
            {
                var client = new HttpClient();

                var response = await client.GetAsync(url);
                var data = await response.Content.ReadAsStringAsync();
                ViewBag.Cate = System.Text.Json.JsonSerializer.Deserialize<List<Category>>(data);

                response = await client.GetAsync(urlProduct);
                data = await response.Content.ReadAsStringAsync();
                ViewBag.ListP = System.Text.Json.JsonSerializer.Deserialize<List<Product>>(data);

                client.Dispose();
                return View();
            }
            catch (Exception e)
            {
                throw;
            }

        }
        public async Task<IActionResult> CreateAsync()
        {
            try
            {
                var client = new HttpClient();
                var response = await client.GetAsync(url);
                var data = await response.Content.ReadAsStringAsync();
                ViewBag.Categories = System.Text.Json.JsonSerializer.Deserialize<List<Category>>(data);
                client.Dispose();
                return View();
            }
            catch (Exception e)
            {
                throw;
            }


        }
        [HttpPost]
        public IActionResult CreateAsync(string title, int type, decimal price, string img, int iss, string des, int am)
        {

            try
            {
                return RedirectToAction("Index");

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IActionResult> DetailAsync(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            Product products = new Product();
            try
            {
                var client = new HttpClient();
                var response = await client.GetAsync(urlProduct + "/id?id=" + id);
                var data = await response.Content.ReadAsStringAsync();
                ViewBag.P = System.Text.Json.JsonSerializer.Deserialize<Product>(data);
                client.Dispose();
                return View();
            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task<IActionResult> DeleteItemAsync(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            try
            {
                var client = new HttpClient();
                var response = await client.DeleteAsync(urlProduct + "?id=" + id);

                //if (response.IsSuccessStatusCode) Console.WriteLine("Delete successfully");
                //else Console.WriteLine("Delete fail");
                client.Dispose();
                return RedirectToAction("Index");
            }
            catch (Exception)
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
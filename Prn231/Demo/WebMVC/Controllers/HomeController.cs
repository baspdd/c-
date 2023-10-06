using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Refit;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;
using WebMVC.Models;

using Refit;
using Newtonsoft.Json;




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
        //public async Task<IActionResult> IndexAsync()
        //{
        //    try
        //    {
        //        var client = new HttpClient();

        //        var response = await client.GetAsync(url);
        //        var data = await response.Content.ReadAsStringAsync();
        //        ViewBag.Cate = System.Text.Json.JsonSerializer.Deserialize<List<Category>>(data);

        //        response = await client.GetAsync(urlProduct);
        //        data = await response.Content.ReadAsStringAsync();
        //        ViewBag.ListP = System.Text.Json.JsonSerializer.Deserialize<List<Product>>(data);

        //        client.Dispose();

        //        return View();
        //    }
        //    catch (Exception e)
        //    {
        //        throw;
        //    }

        //}

        public interface ICategoryApi
        {
            [Get("/api/Category")]
            Task<List<Category>> GetCategories();
        }

        public interface IProductApi
        {
            [Get("/api/Product")]
            Task<List<Product>> GetProducts();
        }
        string local = "http://localhost:5110";
        public async Task<IActionResult> IndexAsync()
        {
            try
            {
                
                var categoryApi = RestService.For<ICategoryApi>(local);
                ViewBag.Cate = await categoryApi.GetCategories();

                var productApi = RestService.For<IProductApi>(local);
                ViewBag.ListP = await productApi.GetProducts();


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
        public async Task<IActionResult> CreateAsync(string name, int categoryId, decimal unitPrice, int unitsInStock, string img)
        {
            try
            {
                Product pro = new Product
                {
                    productName = name,
                    categoryId = categoryId,
                    unitPrice = unitPrice,
                    unitsInStock = unitsInStock,
                    image = img
                };
                var client = new HttpClient();
                var response = await client.PostAsJsonAsync(urlProduct, pro);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
            }
            return View();
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
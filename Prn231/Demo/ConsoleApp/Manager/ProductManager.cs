using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Models;

namespace ConsoleApp.Manager
{
    internal class ProductManager
    {
        string url = "http://localhost:5110/api/Product";



        internal async Task AddProductAsync()
        {
            Console.WriteLine("Enter name search :");
            var name = Console.ReadLine();
            Product cate = new Product { productName = name };
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = await client.PostAsJsonAsync(url, cate))
                    {
                        if (response.IsSuccessStatusCode) Console.WriteLine("Add successfully");
                        else Console.WriteLine("Add fail");
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Insert error : " + e.Message);
            }
        }

        internal async Task UpdateProductAsync()
        {
            Console.WriteLine("Enter Product up :");
            var id = int.Parse(Console.ReadLine());
            var name = Console.ReadLine();
            Product cate = new Product
            {
                productId = id,
                productName = name
            };

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = await client.PutAsJsonAsync(url, cate))
                    {
                        if (response.IsSuccessStatusCode) Console.WriteLine("Up successfully");
                        else
                        {
                            if (response.StatusCode == HttpStatusCode.NotFound) Console.WriteLine("Not found");
                            else Console.WriteLine("up fail");
                        }
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Up error : " + e.Message);
            }
        }
        internal async Task DeleteProductAsync()
        {
            Console.WriteLine("Enter cate search :");
            var id = int.Parse(Console.ReadLine());
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = await client.DeleteAsync(url + "?id=" + id))
                    {
                        if (response.IsSuccessStatusCode) Console.WriteLine("Delete successfully");
                        else Console.WriteLine("Delete fail");
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Delete error : " + e.Message);
            }
        }
    }
}

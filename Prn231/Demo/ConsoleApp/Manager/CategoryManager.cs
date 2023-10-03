﻿using ConsoleApp.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace ConsoleApp.Manager
{
    internal class CategoryManager
    {

        string url = "http://localhost:5110/api/Category";

        internal async Task AddCategoryAsync()
        {
            Console.WriteLine("Enter name search :");
            var name = Console.ReadLine();
            Category cate = new Category { categoryName = name };
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

        internal async Task DeleteCategoryAsync()
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



        internal async Task SearchCategoryAsync()
        {
            Console.WriteLine("Enter id :");
            int id = Convert.ToInt32(Console.ReadLine());
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = await client.GetAsync(url + "/id?id=" + id))
                    {
                        using (HttpContent content = response.Content)
                        {
                            string data = await content.ReadAsStringAsync();
                            var cate = System.Text.Json.JsonSerializer.Deserialize<Category>(data);
                            Console.WriteLine(cate);
                        }
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Showlist error : " + e.Message);
            }
        }

        internal async Task SearchCategoryByNameAsync()
        {
            Console.WriteLine("Enter name search :");
            var name = Console.ReadLine();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = await client.GetAsync(url + "/name?name=" + name))
                    {
                        using (HttpContent content = response.Content)
                        {
                            string data = await content.ReadAsStringAsync();
                            var cate = System.Text.Json.JsonSerializer.Deserialize<List<Category>>(data);
                            foreach (var item in cate)
                            {
                                Console.WriteLine(item);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Showlist error : " + e.Message);
            }
        }

        internal async Task ShowListAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = await client.GetAsync(url))
                    {
                        using (HttpContent content = response.Content)
                        {
                            string data = await content.ReadAsStringAsync();
                            var cate = System.Text.Json.JsonSerializer.Deserialize<List<Category>>(data);
                            var categories = JsonConvert.DeserializeObject<List<Category>>(data);
                            foreach (var item in categories)
                            {
                                Console.WriteLine(item);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Showlist error : " + e.Message);
            }
        }

        internal async Task UpdateCategoryAsync()
        {
            Console.WriteLine("Enter cate search :");
            var id = int.Parse(Console.ReadLine());
            var name = Console.ReadLine();
            Category cate = new Category
            {
                categoryId = id,
                categoryName = name,
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

    }
}
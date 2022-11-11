using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Globalization;
using System.Web;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;
using System.Security.Cryptography;
using System;

namespace ProjectPRN211.Controllers
{
    public class HomeController : Controller
    {
        static ASMSSContext context = new ASMSSContext();

        public IActionResult Shop(int id)
        {
            try
            {
                List<Product> products = context.Products.ToList();
                List<Category> cate = context.Categories.ToList();
                if (id > 0)
                {
                    products = context.Products.Where(p => p.Type == id).ToList();
                }
                ViewBag.Cate = cate;
                ViewBag.ListP = products;
                return View();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public IActionResult Search(string? search)
        {
            try
            {
                List<Product> products = context.Products.ToList();
                List<Category> cate = context.Categories.ToList();
                if (!string.IsNullOrEmpty(search))
                {
                    products = context.Products.Where(p => p.Title.ToLower().Contains(search.ToLower())).ToList();
                }
                ViewBag.Cate = cate;
                ViewBag.ListP = products;
                return View("Shop");
            }
            catch (Exception)
            {

                throw;
            }

        }


        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(string name, string pass)
        {
            try
            {
               User us = context.Users.FirstOrDefault(u => u.Username.Equals(name) && u.Password.Equals(pass));
                if (us != null)
                {
                    HttpContext.Session.SetString("uid", us.Id.ToString());
                    return RedirectToAction("Shop");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        public IActionResult AddtoCart(int pid, int quantity)
        {
            string uid = HttpContext.Session.GetString("uid");
            if (string.IsNullOrEmpty(uid))
            {
                return RedirectToAction("Login");
            }
            Product pro = context.Products.FirstOrDefault(p => p.Id == pid);
            if (pro.Amount==0)
            {
                return RedirectToAction("Shop");
            }
            pro.Amount -= quantity;
            context.Products.Update(pro);
            double ret = (double)(pro.Price * (100 - pro.IsSale) / 100 * quantity);
            Order order = context.Orders.FirstOrDefault(p => p.Uid == Int32.Parse(uid) && p.Status == 0);
            if (order != null)
            {

                addExist(pid, quantity, order.Id);
                order.Total += (int)ret;
                context.Orders.Update(order);
            }
            else
            {
                addNew(pid, quantity, ret,uid);

            }
            context.SaveChanges();

            return RedirectToAction("Cart");

        }

        private void addExist(int pid, int quantity, int oid)
        {
            try
            {
                OrderItem ot = context.OrderItems.FirstOrDefault(p => p.Oid == oid && p.ProId == pid);
                if (ot != null)
                {
                    ot.Amount += quantity;
                    context.OrderItems.Update(ot);
                }
                else
                {
                    context.OrderItems.Add(new OrderItem
                    {
                        Oid = oid,
                        ProId = pid,
                        Amount = quantity
                    });

                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        private void addNew(int pid, int quantity, double ret, string uid)
        {
            try
            {
                context.Orders.Add(new Order
                {
                    Uid = Int32.Parse(uid),
                    Status = 0,
                    Total = (int)ret
                });
                context.SaveChanges();
                Order ot = context.Orders.ToList().Last();
                context.OrderItems.Add(new OrderItem
                {
                    Oid = ot.Id,
                    ProId = pid,
                    Amount = quantity
                });

            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpPost]
        public IActionResult UpdateCartItem(int pid, int quantity)
        {
            try
            {
                string uid = HttpContext.Session.GetString("uid");
                
                Order order = context.Orders.FirstOrDefault(p => p.Uid == Int32.Parse(uid) && p.Status == 0);

                OrderItem ite = context.OrderItems.FirstOrDefault(p => p.Oid == order.Id && p.ProId == pid);
                int ret = quantity - ite.Amount;
                ite.Amount += ret;

                Product pro = context.Products.FirstOrDefault(p => p.Id == pid);
                pro.Amount -= ret;
                double total = (double)(pro.Price * (100 - pro.IsSale) / 100 * ret);
                order.Total += (int)total;

                context.Products.Update(pro);
                context.OrderItems.Update(ite);
                context.Orders.Update(order);
                context.SaveChanges();
                return RedirectToAction("Cart");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IActionResult Detail(int? id)
        {
            try
            {
                if (id == null)
                {
                    return RedirectToAction("Shop");
                }
                context.Categories.ToList();
                ViewBag.P = context.Products.FirstOrDefault(p => p.Id == id);
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public IActionResult Cart()
        {
            try
            {
                string uid = HttpContext.Session.GetString("uid");
                if (string.IsNullOrEmpty(uid))
                {
                    return RedirectToAction("Login");
                }
                Order order = context.Orders.FirstOrDefault(p => p.Uid == Int32.Parse(uid) && p.Status == 0);
                if (order != null)
                {
                    List<OrderItem> item = context.OrderItems.Where(p => p.Oid == order.Id).OrderBy(p => p.ProId).ToList();
                    List<Category> cate = context.Categories.ToList();

                    context.Categories.ToList();
                    ViewBag.ListO = item;
                    ViewBag.order = order;
                    return View();
                }
                else
                {
                    return RedirectToAction("Shop");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        public IActionResult CartDetail(int oid)
        {
            try
            {
                Order order = context.Orders.FirstOrDefault(p => p.Id == oid);
                List<OrderItem> item = context.OrderItems.Where(p => p.Oid == order.Id).OrderBy(p => p.ProId).ToList();

                ViewBag.ListO = item;
                ViewBag.order = order;
                return View();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public IActionResult DeleteItem(int odid)
        {
            try
            {

                OrderItem ite = context.OrderItems.FirstOrDefault(item => item.Id == odid);

                Product pro = context.Products.FirstOrDefault(p => p.Id == ite.ProId);
                double ret = (double)(pro.Price * (100 - pro.IsSale) / 100 * ite.Amount);
                pro.Amount += ite.Amount;
                Order order = context.Orders.FirstOrDefault(p => p.Id == ite.Oid);
                order.Total -= (int)ret;

                context.Products.Update(pro);
                context.OrderItems.Remove(ite);
                context.Orders.Update(order);
                context.SaveChanges();
                return RedirectToAction("cart");

            }
            catch (Exception)
            {

                throw;
            }

        }
        public IActionResult CheckOut()
        {
            try
            {
                string uid = HttpContext.Session.GetString("uid");
                if (string.IsNullOrEmpty(uid))
                {
                    return RedirectToAction("Shop");
                }
                Order order = context.Orders.FirstOrDefault(p => p.Uid == Int32.Parse(uid) && p.Status == 0);
                order.Status = 1;
                order.Send = DateTime.Today;
                context.Orders.Update(order);
                context.SaveChanges();
                return RedirectToAction("OrderManage");

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IActionResult OrderManage()
        {
            try
            {
                string uid = HttpContext.Session.GetString("uid");
                if (string.IsNullOrEmpty(uid))
                {
                    return RedirectToAction("Login");
                }
                List<Order> listO = context.Orders.Where(p => p.Uid == Int32.Parse(uid)).ToList();
                ViewBag.listO = listO;
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public IActionResult ProMana()
        {
            try
            {
                context.Categories.ToList();
                List<Product> list = context.Products.ToList();
                ViewBag.products = list;
                return View();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IActionResult UpdateProduct(int pid)
        {
            try
            {
                Product p = context.Products.FirstOrDefault(p => p.Id == pid);
                ViewBag.P = p;
                return View(p);

            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public IActionResult UpdateProduct(int? pid, int isS, string title, int type, int price, string des, int am, string img)
        {
            try
            {

                Product Pro = context.Products.FirstOrDefault(p => p.Id == pid);
                ViewBag.test = pid;
                return View();
                //Pro.Title = title;
                //Pro.Type = type;
                //Pro.Price = price;
                //Pro.Image = img;
                //Pro.IsSale = isS;
                //Pro.Description = des;
                //Pro.Amount = am;
                //context.Products.Update(Pro);
                //context.SaveChanges();
                //return RedirectToAction("ProMana");

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult UpdateProduct2(int? pid, int quantity)
        {
            try
            {

                Product Pro = context.Products.FirstOrDefault(p => p.Id == pid);
                Pro.Amount = quantity;
                context.Products.Update(Pro);
                context.SaveChanges();
                return RedirectToAction("ProMana");

            }
            catch (Exception)
            {

                throw;
            }
        }
        public IActionResult AddProduct()
        {
            ViewBag.Categories = context.Categories.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(string title, int type, decimal price, string img, int iss, string des, int am)
        {
            try
            {
                Product product = new Product
                {
                    Title = title,
                    Type = type,
                    Price = price,
                    Image = img,
                    IsSale = iss,
                    Description = des,
                    Amount = am
                };
                context.Products.Add(product);
                context.SaveChanges();
                return RedirectToAction("ProMana");
                
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}

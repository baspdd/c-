using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Globalization;
using System.Web;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;
using System.Security.Cryptography;

namespace ProjectPRN211.Controllers
{
    public class HomeController : Controller
    {
        static ASMSSContext context = new ASMSSContext();
        static User us = new User();

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


        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(string name, string pass)
        {
            try
            {
                us = context.Users.FirstOrDefault(u => u.Username.Equals(name) && u.Password.Equals(pass));
                if (us != null)
                {
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
            Product pro = context.Products.FirstOrDefault(p => p.Id == pid);
            double ret = (double)(pro.Price * (100 - pro.IsSale) / 100 * quantity);
            Order order = context.Orders.FirstOrDefault(p => p.Uid == 1 && p.Status == 0);
            if (order != null)
            {

                addExist(pid, quantity, order.Id);
                order.Total += (int)ret;
                context.Orders.Update(order);
            }
            else
            {
                addNew(pid, quantity, ret);

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

        private void addNew(int pid, int quantity, double ret)
        {
            try
            {
                context.Orders.Add(new Order
                {
                    Uid = us.Id,
                    Status = 0,
                    Total = (int)ret
                });
                Order ot = context.Orders.Last();
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
                Order order = context.Orders.FirstOrDefault(p => p.Uid == 1 && p.Status == 0);
                if (order != null)
                {
                    List<OrderItem> item = context.OrderItems.Where(p => p.Oid == order.Id).ToList();
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
        public IActionResult DeleteItem(int odid)
        {
            try
            {

                OrderItem ite = context.OrderItems.FirstOrDefault(item => item.Id == odid);
                context.OrderItems.Remove(ite);

                Product pro = context.Products.FirstOrDefault(p => p.Id == ite.ProId);
                double ret = (double)(pro.Price * (100 - pro.IsSale) / 100 * ite.Amount);
                Order order = context.Orders.FirstOrDefault(p => p.Id == ite.Oid);
                order.Total -= (int)ret;
                context.Orders.Update(order);
                context.SaveChanges();
                return RedirectToAction("cart");

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
                List<Product> list = context.Products.ToList();
                ViewBag.products = list;
                return View();

            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}

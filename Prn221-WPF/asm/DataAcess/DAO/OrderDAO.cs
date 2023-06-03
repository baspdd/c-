using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.DAO
{
    internal class OrderDAO
    {
        private static OrderDAO instance = null;
        private static readonly object instanceLock = new object();
        private OrderDAO() { }
        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                    return instance;
                }
            }
        }


        internal IEnumerable<Order> getAllOrders()
        {
            List<Order> orderList;
            try
            {
                using (var dbcontext = new MyStoreContext())
                {
                    orderList = dbcontext.Orders.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderList;
        }

        internal void addOrders(Order order)
        {
            try
            {
                Order duplicate = getOrderById(order.OrderId);
                if (duplicate == null)
                {
                    using (var dbContext = new MyStoreContext())
                    {
                        dbContext.Add(order);
                        dbContext.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("This order already exists");
            }
        }
        internal void updateOrder(Order order)
        {
            try
            {
                Order o = getOrderById(order.OrderId);
                if (o != null)
                {
                    using (var dbContext = new MyStoreContext())
                    {
                        dbContext.Entry(order).State = EntityState.Modified;
                        dbContext.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("This order does not exist");
            }
        }
        internal void deleteOrders(Order order)
        {
            try
            {
                Order o = getOrderById(order.OrderId);
                if (o != null)
                {
                    using (var dbContext = new MyStoreContext())
                    {
                        dbContext.Orders.Remove(order);
                        dbContext.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("This order doesn't exist");
            }
        }



        internal Order getOrderById(int id)
        {

            Order order = null;
            try
            {
                using (var dbContext = new MyStoreContext())
                {
                    order = dbContext.Orders.SingleOrDefault(o => o.OrderId == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return order;
        }

        internal IEnumerable<Order> getOrdersByDate(DateTime startDate, DateTime endDate)
        {
            List<Order> orderList;
            try
            {
                using (var db = new MyStoreContext())
                {
                    orderList = db.Orders.Where(o => o.OrerDate >= startDate && o.OrerDate <= endDate).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderList;
        }
        internal IEnumerable<Order> getOrdersByUser(string email)
        {
            List<Order> orderList;
            try
            {
                using (var db = new MyStoreContext())
                {
                    int memberId = db.Members.FirstOrDefault(m => m.Email == email).MemberId;
                    orderList = db.Orders.Where(o => o.MemberId == memberId).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderList;
        }
    }
}

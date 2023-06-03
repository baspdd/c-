using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> getAllOrders();
        void addOrder(Order order);
        void updateOrder(Order order);
        void deleteOrder(Order order);
        Order getOrderById(int id);
        IEnumerable<Order> getOrdersByUser(string email);
        IEnumerable<Order> getOrdersByDate(DateTime startDate, DateTime endDate);
    }
}

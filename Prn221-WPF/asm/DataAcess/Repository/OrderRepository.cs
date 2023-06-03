using BusinessObject.Models;
using DataAcess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public IEnumerable<Order> getAllOrders() => OrderDAO.Instance.getAllOrders();
        public void addOrder(Order order) => OrderDAO.Instance.addOrders(order);
        public void updateOrder(Order order) => OrderDAO.Instance.updateOrder(order);
        public void deleteOrder(Order order) => OrderDAO.Instance.deleteOrders(order);
        public Order getOrderById(int id) => OrderDAO.Instance.getOrderById(id);
        public IEnumerable<Order> getOrdersByDate(DateTime startDate, DateTime endDate) => OrderDAO.Instance.getOrdersByDate(startDate, endDate);
        public IEnumerable<Order> getOrdersByUser(string email) => OrderDAO.Instance.getOrdersByUser(email);
    }
}

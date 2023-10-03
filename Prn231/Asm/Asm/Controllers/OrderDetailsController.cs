using Asm.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Security.Cryptography;

namespace Asm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        //Get:api/Category
        [HttpGet]
        public IActionResult GetAllOrder()
        {
            using (MySaleDBContext db = new MySaleDBContext())
            {
                return Ok(db.OrdersDetails.ToList());
            }
        }
        //Get:api/Order/id
        [HttpGet("id")]
        public IActionResult GetOrderById(int orderId, int productID)
        {
            using (MySaleDBContext db = new MySaleDBContext())
            {
                var cate = db.OrdersDetails.SingleOrDefault(cate => cate.OrderId == orderId && cate.ProductId == productID);
                if (cate == null) return NotFound();
                return Ok(cate);
            }
        }

        //Post:api/Order
        [HttpPost]
        public IActionResult AddOrder(int oid, int pid, int quantity, double discount)
        {
            using (MySaleDBContext db = new MySaleDBContext())
            {
                var p = db.Products.SingleOrDefault(cate => cate.ProductId == pid);
                var o = db.Orders.SingleOrDefault(cate => cate.OrderId == oid);
                if (p == null || o == null) return NotFound();
                if (discount > 100) return BadRequest();
                var check = db.OrdersDetails.SingleOrDefault(cate => cate.OrderId == oid && cate.ProductId == pid);
                if (check != null) return BadRequest();
                OrdersDetail order = new OrdersDetail();
                order.ProductId = pid;
                order.OrderId = oid;
                order.UnitPrice = p.UnitPrice;
                order.Quantity = quantity;
                order.Discount = discount;
                db.OrdersDetails.Add(order);
                db.SaveChanges();
                return Ok();
            }
        }

        //Post:api/Order
        [HttpPost("idss")]
        public IActionResult AddOrder2(OrderDetail od)
        {
            using (MySaleDBContext db = new MySaleDBContext())
            {
                var p = db.Products.SingleOrDefault(cate => cate.ProductId == od.ProductId);
                var o = db.Orders.SingleOrDefault(cate => cate.OrderId == od.OrderId);
                if (p == null || o == null) return NotFound();
                if (od.Discount > 100) return BadRequest();
                var check = db.OrdersDetails.SingleOrDefault(cate => cate.OrderId == od.OrderId && cate.ProductId == od.ProductId);
                if (check != null) return BadRequest();
                OrdersDetail order = new OrdersDetail();
                order.ProductId = od.ProductId;
                order.OrderId = od.OrderId;
                order.UnitPrice = p.UnitPrice;
                order.Quantity = od.Quantity;
                order.Discount = od.Discount;
                db.OrdersDetails.Add(order);
                db.SaveChanges();
                return Ok();
            }
        }

        [HttpPut]
        public IActionResult UpdateOrder(int oid, int pid, int quantity, double discount)
        {
            using (MySaleDBContext db = new MySaleDBContext())
            {
                var order = db.OrdersDetails.SingleOrDefault(cate => cate.OrderId == oid && cate.ProductId == pid);
                if (order == null) return NotFound();
                order.Quantity = quantity;
                order.Discount = discount;
                db.OrdersDetails.Update(order);
                db.SaveChanges();
                return Ok();
            }
        }

        [HttpDelete]
        public IActionResult DeleteOrder(int oid, int pid)
        {
            using (MySaleDBContext db = new MySaleDBContext())
            {
                var order = db.OrdersDetails.SingleOrDefault(cate => cate.OrderId == oid && cate.ProductId == pid);
                if (order == null) return NotFound();
                db.OrdersDetails.Remove(order);
                db.SaveChanges();
                return Ok();
            }
        }
    }
}

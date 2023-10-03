using Asm.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace Asm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderAPIController : ControllerBase
    {
        //Get:api/Category
        [HttpGet]
        public IActionResult GetAllOrder()
        {
            using (MySaleDBContext db = new MySaleDBContext())
            {
                return Ok(db.Orders.ToList());
            }
        }
        //Get:api/Order/id
        [HttpGet("id")]
        public IActionResult GetOrderById(int id)
        {
            using (MySaleDBContext db = new MySaleDBContext())
            {
                var cate = db.Orders.SingleOrDefault(cate => cate.OrderId == id);
                if (cate == null) return NotFound();
                return Ok(cate);
            }
        }

        //Post:api/Order
        [HttpPost]
        public IActionResult AddOrder(int memId, DateTime required, DateTime shipped)
        {
            using (MySaleDBContext db = new MySaleDBContext())
            {
                var mem = db.Members.SingleOrDefault(cate => cate.MemberId == memId);
                if (mem == null) return NotFound();
                Order order = new Order();
                order.MemberId = memId;
                order.OrderDate = DateTime.Now;
                order.RequiredDate = required;
                order.ShippedDate = shipped;
                order.Freight = 1;
                db.Orders.Add(order);
                db.SaveChanges();
                return Ok();
            }
        }

        [HttpPut]
        public IActionResult UpdateOrder(int oid, int memId, DateTime required, DateTime shipped, int freigh)
        {
            using (MySaleDBContext db = new MySaleDBContext())
            {
                var mem = db.Members.SingleOrDefault(cate => cate.MemberId == memId);
                var or = db.Orders.SingleOrDefault(o => o.OrderId == oid);
                if (or == null || mem == null) return NotFound();
                or.MemberId = memId;
                or.RequiredDate = required;
                or.ShippedDate = shipped;
                or.Freight = freigh;
                db.Orders.Update(or);
                db.SaveChanges();
                return Ok();
            }
        }

        [HttpDelete]
        public IActionResult DeleteOrder(int id)
        {
            using (MySaleDBContext db = new MySaleDBContext())
            {
                var or = db.Orders.Include(o => o.OrdersDetails).SingleOrDefault(o => o.OrderId == id);
                if (or == null) return NotFound();
                or.OrdersDetails.Clear();
                db.Orders.Remove(or);
                db.SaveChanges();
                return Ok(db.Orders.ToList());
            }
        }
    }
}

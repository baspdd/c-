using Microsoft.EntityFrameworkCore;
using SignalRAssignment.Models;

namespace SignalRAssignment.Service
{
    public class OrderDAO
    {
        private readonly SignalRAssignment.Models.MyStoreContext dbContext;

        public OrderDAO()
        {
            dbContext = new MyStoreContext();
        }

        public async Task<IList<Order>> getAllOrdersByCusID()
        {
            return await dbContext.Orders
                 .Include(o => o.Customer).ToListAsync();
        }

        public Task<OrderDetail> getOrderDetailsByID(string id)
        {
            return dbContext.OrderDetails
                .Include(o => o.Order)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.OrderId == id);
        }
    }
}

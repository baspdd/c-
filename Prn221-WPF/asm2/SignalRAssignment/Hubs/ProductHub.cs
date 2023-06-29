using Microsoft.AspNetCore.SignalR;
using SignalRAssignment.Models;
using SignalRAssignment.Service;

namespace SignalRAssignment.Hubs
{
    public class ProductHub :Hub
    {
        public async Task Delete(string productId)
        {
            ProductDAO productDAO = new ProductDAO();
            productDAO.deleteProductAsync(productId);

            await Clients.All.SendAsync("LoadProduct");
        }
    }
}

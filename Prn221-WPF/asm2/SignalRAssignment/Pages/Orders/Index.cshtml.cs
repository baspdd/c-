using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SignalRAssignment.Models;
using SignalRAssignment.Service;

namespace SignalRAssignment.Pages.Orders
{
    public class IndexModel : PageModel
    {

        [BindProperty]
        public IList<Order> Order { get; set; } = default!;
        private OrderDAO orderDAO = new OrderDAO();
        public async Task OnGetAsync(string? id)
        {
            Order = await orderDAO.getAllOrdersByCusID();
        }

        public async Task OnPostAsync(string? id)
        {
            Order = await orderDAO.getAllOrdersByCusID();
            Order = Order.OrderByDescending(o => o.Freight).ToList();
        }
    }
}

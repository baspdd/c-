using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SignalRAssignment.Hubs;
using SignalRAssignment.Models;
using SignalRAssignment.Service;

namespace SignalRAssignment.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private ProductDAO productDAO = new ProductDAO();


        private readonly IHubContext<SignalHub> _hubContext;
        public DeleteModel( IHubContext<SignalHub> hubContext)
        {
            _hubContext = hubContext;
        }
        [BindProperty]
        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var product = await productDAO.getProductByID(id);

            //if (product == null)
            //{
            //    return NotFound();
            //}
            //else
            //{
            //    Product = product;
            //}
            //return Page();
            productDAO.deleteProductAsync(id);
            await _hubContext.Clients.All.SendAsync("ReloadData");
            return RedirectToPage("/Products/Index");
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            productDAO.deleteProductAsync(id);
            return RedirectToPage("/Products/Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SignalRAssignment.Models;
using SignalRAssignment.Service;

namespace SignalRAssignment.Pages.Products
{
    public class IndexModel : PageModel
    {
        private ProductDAO productDAO = new ProductDAO();

        public IList<Product> Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            //var sessionStr = HttpContext.Session.GetString("staff");
            //if (sessionStr == null)
            //{
            //    return RedirectToPage("/Index");
            //}
            Product = await productDAO.getProductsAsync(null);
            return Page();
        }
    }
}

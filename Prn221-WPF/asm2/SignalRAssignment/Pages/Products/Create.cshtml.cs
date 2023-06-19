using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SignalRAssignment.Models;
using SignalRAssignment.Service;

namespace SignalRAssignment.Pages.Products
{
    public class CreateModel : PageModel
    {
        private ProductDAO productDAO = new ProductDAO();
        [BindProperty]
        public Product Product { get; set; } = default!;

        public void OnGet()
        {
            ViewData["CategoryId"] = productDAO.getAllCategories();
            ViewData["SupplierId"] = productDAO.getAllSuppliers();
            ViewData["id"] = productDAO.getLatestProductID();
        }

        
        public async Task<IActionResult> OnPostAsync()
        {
            if (Product == null)
            {
                return Page();
            }

            productDAO.InsertProductAsync(Product);

            return RedirectToPage("/Products/Index");
        }
    }
}

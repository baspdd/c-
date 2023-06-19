using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SignalRAssignment.Models;
using SignalRAssignment.Service;

namespace SignalRAssignment.Pages.Products
{
    public class EditModel : PageModel
    {
        private ProductDAO productDAO = new ProductDAO();

        [BindProperty]
        public Product Product { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await productDAO.getProductByID(id);
            if (product == null)
            {
                return NotFound();
            }
            Product = product;
            ViewData["CategoryId"] = productDAO.getAllCategories();
            ViewData["SupplierId"] = productDAO.getAllSuppliers();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            productDAO.UpdateProductAsync(Product);

            return RedirectToPage("/Products/Index");
        }

    }
}

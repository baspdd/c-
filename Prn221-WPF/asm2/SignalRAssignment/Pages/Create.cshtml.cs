using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SignalRAssignment.Models;
using SignalRAssignment.Service;

namespace SignalRAssignment.Pages
{
    public class CreateModel : PageModel
    {
        private ProductDAO productDAO = new ProductDAO();

        public IActionResult OnGet()
        {
            ViewData["CategoryId"] = productDAO.getAllCategories();
            ViewData["SupplierId"] = productDAO.getAllSuppliers();
            ViewData["id"] = productDAO.getLatestProductID();
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Product == null)
            {
                return Page();
            }

            productDAO.InsertProductAsync(Product);

            return RedirectToPage("./Index");
        }
    }
}

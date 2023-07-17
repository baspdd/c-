using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Question2.Model;

namespace Question2.Pages
{
    public class ProductsModel : PageModel
    {

        [BindProperty]
        public List<Category> Categories { get; set; }

        [BindProperty]
        public List<Product> Products { get; set; }
        public void OnGet(int id)
        {
            PE_PRN_23SumContext db = new PE_PRN_23SumContext();
            Categories = db.Categories.ToList();
            Products = db.Products.Include(p => p.Category)
                .ToList();
        }
    }
}

using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Demo.Pages
{
    public class CategoryModel : PageModel
    {
        private MySaleDBContext db = new MySaleDBContext();

        public IList<Category> ListCategory { get; set; } = default!;
        [BindProperty]
        public Category Category { get; set; } = default!;
        public IActionResult OnGet()
        {
            ListCategory = db.Categories.ToList();
            return Page();
        }


        public async Task OnPostAsync(string func)
        {
            try
            {
                if (func.Equals("Add"))
                {
                    db.Categories.Add(Category);
                }
                else
                {
                    db.Categories.Update(Category);
                }
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            ListCategory = await db.Categories.ToListAsync();
        }
    }
}

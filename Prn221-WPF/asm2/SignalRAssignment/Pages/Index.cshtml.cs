using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SignalRAssignment.Models;

namespace SignalRAssignment.Pages
{
    public class IndexModel : PageModel
    {

        private readonly SignalRAssignment.Models.MyStoreContext dbContext;

        public IndexModel(SignalRAssignment.Models.MyStoreContext context)
        {
            dbContext = context;
        }


        [BindProperty]
        public string nameSearch { get; set; }

        public IList<Product> Products { get; set; }
        public async Task OnGetAsync()
        {
            try
            {
                string nameSearch = Request.Query["nameSearch"];

                IQueryable<Product> query = dbContext.Products
                    .Include(product => product.Supplier)
                    .Include(product => product.Category);

                if (!String.IsNullOrEmpty(nameSearch))
                {
                    query = query
                        .Where(product => product.ProductName.ToUpper().Contains(nameSearch.ToUpper()));
                }

                Products = await query.ToListAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

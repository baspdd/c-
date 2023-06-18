using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SignalRAssignment.Models;
using SignalRAssignment.Service;

namespace SignalRAssignment.Pages
{
    public class IndexModel : PageModel
    {

        private ProductDAO productDAO = new ProductDAO();


        [BindProperty]
        public string nameSearch { get; set; }

        public IList<Product> Products { get; set; }
        public async Task OnGetAsync()
        {
            try
            {
                string nameSearch = Request.Query["nameSearch"];
                Products = await productDAO.getProductsAsync(nameSearch );

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

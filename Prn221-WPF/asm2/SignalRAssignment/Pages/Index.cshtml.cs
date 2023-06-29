using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SignalRAssignment.Models;
using SignalRAssignment.Service;

namespace SignalRAssignment.Pages
{
    public class IndexModel : PageModel
    {

        private ProductDAO productDAO = new ProductDAO();


        [BindProperty]
        public string strSearch { get; set; }

        public IList<Product> Products { get; set; }
        public async Task OnGetAsync()
        {
            try
            {
                strSearch = Request.Query["strSearch"];
                Products = await productDAO.getProductsAsync(strSearch);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task OnPostAsync(IFormFile inpFile)
        {
            string fileContent = string.Empty;
            using (var reader = new StreamReader(inpFile.OpenReadStream()))
            {
                fileContent = reader.ReadToEnd();
            }
            if (String.IsNullOrEmpty(fileContent))
            {
                var list = JsonConvert.DeserializeObject<List<Product>>(fileContent);
                if (list.Count > 0)
                {
                    Products = list;
                }
                else { Products = await productDAO.getProductsAsync(null); }
            }
        }
    }
}

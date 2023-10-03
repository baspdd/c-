using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebMVVM.Models;

namespace WebMVVM.Pages
{
    public class IndexModel : PageModel
    {
        string url = "http://localhost:5110/api/Category";
        string urlProduct = "http://localhost:5110/api/Product";


        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }


        public async Task OnGetAsync()
        {
            try
            {
                var client = new HttpClient();

                var response = await client.GetAsync(url);
                var data = await response.Content.ReadAsStringAsync();
                ViewData["Cate"] = System.Text.Json.JsonSerializer.Deserialize<List<Category>>(data);

                response = await client.GetAsync(urlProduct);
                data = await response.Content.ReadAsStringAsync();
                ViewData["ListP"] = System.Text.Json.JsonSerializer.Deserialize<List<Product>>(data);

                client.Dispose();
            }
            catch (Exception e)
            {
                throw;
            }

        }
    }
}
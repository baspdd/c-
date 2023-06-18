using Azure.Core;
using Microsoft.EntityFrameworkCore;
using SignalRAssignment.Models;

namespace SignalRAssignment.Service
{
    public class ProductDAO
    {
        private readonly SignalRAssignment.Models.MyStoreContext dbContext;


        public ProductDAO()
        {
            dbContext = new MyStoreContext();
        }


        public async Task<IList<Product>> getProductsAsync(string? nameSearch)
        {
            try
            {
                IQueryable<Product> query = dbContext.Products
                    .Include(product => product.Supplier)
                    .Include(product => product.Category);

                if (!String.IsNullOrEmpty(nameSearch))
                {
                    query = query
                        .Where(product => product.ProductName.ToUpper().Contains(nameSearch.ToUpper()));
                }

                return await query.ToListAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

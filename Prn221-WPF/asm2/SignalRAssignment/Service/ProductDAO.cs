using Azure.Core;
using Microsoft.AspNetCore.Mvc.Rendering;
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
                        .Where(product => product.ProductName.ToUpper().Contains(nameSearch.ToUpper())
                        
                        );
                }

                return await query.ToListAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public string getLatestProductID()
        {
            try
            {
                string newId;
                var lastAccount = dbContext.Products.OrderBy(p => p.ProductId).LastOrDefault();
                if (lastAccount != null)
                {
                    var currentVal = Int32.Parse(lastAccount.ProductId.Substring(4));
                    var nextVal = currentVal + 1;
                    newId = $"PROD{nextVal:D3}";
                }
                else
                {
                    newId = "PROD001"; // Default value if there are no existing accounts
                }
                return newId;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task InsertProductAsync(Product product)
        {
            try
            {
                dbContext.Products.Add(product);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateProductAsync(Product product)
        {
            try
            {
                dbContext.Attach(product).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<Product> getProductByID(string id)
        {
            try
            {
                return dbContext.Products
                      .Include(product => product.Supplier)
                    .Include(product => product.Category)
                    .FirstOrDefaultAsync(m => m.ProductId == id);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task deleteProductAsync(string id)
        {
            var product = await getProductByID(id);
            if (product != null)
            {
                dbContext.Products.Remove(product);
                await dbContext.SaveChangesAsync();
            }
        }

        public SelectList getAllCategories()
        {
            return new SelectList(dbContext.Categories, "CategoryId", "CategoryName");
        }

        public SelectList getAllSuppliers()
        {
            return new SelectList(dbContext.Suppliers, "SupplierId", "CompanyName");
        }

        public bool ProductExists(string id)
        {
            return (dbContext.Products?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }
    }
}

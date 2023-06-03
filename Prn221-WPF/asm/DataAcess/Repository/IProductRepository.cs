using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> getAllProducts();
        void addProduct(Product product);
        void updateProduct(Product product);
        void deleteProduct(Product product);
        Product getProductById(int id);
        IEnumerable<Product> getProductsByQuantity(int unit);
        IEnumerable<Product> getProductsByPrice(decimal price);
    }
}

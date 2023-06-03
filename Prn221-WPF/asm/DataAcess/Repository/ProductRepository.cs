using BusinessObject.Models;
using DataAcess.DAO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Repository
{
    public class ProductRepository : IProductRepository
    {
        public void addProduct(Product product) => ProductDAO.Instance.addProduct(product);
        public void deleteProduct(Product product) => ProductDAO.Instance.deleteProduct(product);
        public IEnumerable<Product> getAllProducts() => ProductDAO.Instance.getAllProducts();
        public Product getProductById(int id) => ProductDAO.Instance.getProductById(id);
        public IEnumerable<Product> getProductsByPrice(decimal price) => ProductDAO.Instance.getProductsByPrice(price);
        public IEnumerable<Product> getProductsByQuantity(int unit) => ProductDAO.Instance.getProductsByQuantity(unit);
        public void updateProduct(Product product) => ProductDAO.Instance.updateProduct(product);
    }
}

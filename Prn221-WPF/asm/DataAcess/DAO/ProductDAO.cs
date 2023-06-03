using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.DAO
{
    internal class ProductDAO
    {
        private static ProductDAO instance = null;
        private static readonly object instanceLock = new object();
        private ProductDAO() { }
        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                    return instance;
                }
            }
        }

        internal void addProduct(Product product)
        {
            try
            {
                Product p = getProductById(product.ProductId);
                if (p == null)
                {
                    using (var db = new MyStoreContext())
                    {
                        db.Products.Add(product);
                        db.SaveChanges();
                    }

                }
            }
            catch (Exception)
            {
                throw new Exception("The product already exists");
            }
        }

        internal void deleteProduct(Product product)
        {
            try
            {
                Product p = getProductById(product.ProductId);
                if (p != null)
                {
                    using (var db = new MyStoreContext())
                    {
                        db.Products.Remove(product);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("The product doesn't exist");
            }
        }

        internal IEnumerable<Product> getAllProducts()
        {
            List<Product> productList;
            try
            {
                using (var db = new MyStoreContext())
                {
                    productList = db.Products.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return productList;
        }

        internal Product getProductById(int id)
        {
            Product product = null;
            try
            {
                using (var db = new MyStoreContext())
                {
                    product = db.Products.SingleOrDefault(p => p.ProductId == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return product;
        }

        internal IEnumerable<Product> getProductsByPrice(decimal price)
        {
            List<Product> productList;
            try
            {
                using (var db = new MyStoreContext())
                {
                    productList = db.Products.Where(p => p.UnitPrice == price).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return productList;
        }

        internal IEnumerable<Product> getProductsByQuantity(int unit)
        {
            List<Product> productList;
            try
            {
                using (var db = new MyStoreContext())
                {
                    productList = db.Products.Where(p => p.UnitsInStock == unit).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return productList;
        }

        internal void updateProduct(Product product)
        {
            try
            {
                Product p = getProductById(product.ProductId);
                if (p != null)
                {
                    using (var db = new MyStoreContext())
                    {
                        db.Entry(product).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

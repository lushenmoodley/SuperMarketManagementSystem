﻿using WebApp.Models;

namespace SupermarketManagementSystem.Models
{
    public class ProductsRepository
    {
        private static List<Product> _products = new List<Product>()
        {
            new Product { ProductId = 1, Categoryid = 1, Name = "Iced Tea", Quantity = 100, Price = 1.99 },
            new Product { ProductId = 2, Categoryid = 1, Name = "Canada Dry", Quantity = 200, Price = 1.99 },
            new Product { ProductId = 3, Categoryid = 2, Name = "Whole Wheat Bread", Quantity = 300, Price = 1.50 },
            new Product { ProductId = 4, Categoryid = 2, Name = "White Bread", Quantity = 300, Price = 1.50 }
        };

        public static void AddProduct(Product product)
        {
            
            if(_products!=null && _products.Count>0)
            {
                var maxId = _products.Max(x => x.ProductId);
                product.ProductId = maxId + 1;
            }
            else
            {
                product.ProductId = 1;
            }

            if (product == null) _products = new List<Product>();

                _products.Add(product);
        }

        public static List<Product> GetProducts(bool loadCategory=false)
        {
            if(!loadCategory)
            {
                return _products;
            }
            else
            {
                if(_products!=null && _products.Count>0)
                {
                    _products.ForEach(x =>
                    {
                        if(x.Categoryid!=null)
                        x.Category = CategoriesRepository.GetCategoryById(x.Categoryid);
                    });
                }

                return _products ?? new List<Product>();
            }
        }

        public static Product? GetProductById(int productId, bool loadCategory=false)
        {
            var product = _products.FirstOrDefault(x => x.ProductId == productId);
            if (product != null)
            {
                var prod=new Product
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                    Quantity = product.Quantity,
                    Price = product.Price,
                    Categoryid = product.Categoryid                    
                };

                if(loadCategory)
                {
                    product.Category = CategoriesRepository.GetCategoryById(product.Categoryid);
                }

                return prod;
            }         

            return null;
        }

        public static void UpdateProduct(int productId, Product product)
        {
            if (productId != product.ProductId) return;

            var productToUpdate = _products.FirstOrDefault(x => x.ProductId == productId);
            if (productToUpdate != null)
            {
                productToUpdate.Name = product.Name;
                productToUpdate.Quantity = product.Quantity;
                productToUpdate.Price = product.Price;
                productToUpdate.Categoryid = product.Categoryid;
            }
        }

        public static void DeleteProduct(int productId)
        {
            var product = _products.FirstOrDefault(x => x.ProductId == productId);
            if (product != null)
            {
                _products.Remove(product);
            }
        }
    
        public static List<Product> GetProductsByCategoryId(int categoryId)
        {
            var products = _products.Where(x => x.Categoryid == categoryId);

            if(products!=null)
            {
                return products.ToList();
            }
            else
            {
                return new List<Product>();
            }
        }
    }
}

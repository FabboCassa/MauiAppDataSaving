using MauiAppDataSaving.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppDataSaving.Services
{
    public class ProductService : IProductService
    {
        private readonly List<Product> _products = new();
        public Task AddProductAsync(Product product)
        {
            _products.Add(product);
            return Task.CompletedTask;
        }
        public Task<List<Product>> GetProductsAsync()
        {
            return Task.FromResult(_products);
        }
    }
}

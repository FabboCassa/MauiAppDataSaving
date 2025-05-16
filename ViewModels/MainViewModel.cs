using MauiAppDataSaving.Models;
using MauiAppDataSaving.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiAppDataSaving.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IProductService _productService;

        public ObservableCollection<Product> Products { get; set; } = new();
        public ICommand AddProductCommand { get; }

        public MainViewModel(IProductService productService)
        {
            _productService = productService;
            AddProductCommand = new Command(async () => await AddProductAsync());
            LoadProducts();
        }

        private async Task LoadProducts()
        {
            var products = await _productService.GetProductsAsync();
            foreach (var item in products)
            {
                Products.Add(item);
            }
        }

        private async Task AddProductAsync()
        {
            var newProduct = new Product { Name = "Sample Product", Price = 9.99 };
            await _productService.AddProductAsync(newProduct);
            Products.Add(newProduct);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}

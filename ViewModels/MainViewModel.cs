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

        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                if (_selectedProduct != value)
                {
                    _selectedProduct = value;
                    OnPropertyChanged(nameof(SelectedProduct));
                    EditedName = _selectedProduct?.Name ?? string.Empty; // Fix for CS8601  
                }
            }
        }

        private string _editedName;
        public string EditedName
        {
            get => _editedName;
            set
            {
                if (_editedName != value)
                {
                    _editedName = value;
                    OnPropertyChanged(nameof(EditedName));
                }
            }
        }
        public ICommand AddProductCommand { get; }
        public ICommand SaveProductCommand { get; }

        public MainViewModel(IProductService productService)
        {
            _productService = productService;
            AddProductCommand = new Command(async () => await AddProductAsync());
            SaveProductCommand = new Command(SaveProduct);
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

        private void SaveProduct()
        {
            if (SelectedProduct != null && !string.IsNullOrWhiteSpace(EditedName))
            {
                SelectedProduct.Name = EditedName;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

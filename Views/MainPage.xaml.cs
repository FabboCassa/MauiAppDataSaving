using MauiAppDataSaving.Services;
using MauiAppDataSaving.ViewModels;

namespace MauiAppDataSaving.Views;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		BindingContext = new MainViewModel(new ProductService());
    }
}
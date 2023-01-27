using Mvvm_Product.Models;
using Mvvm_Product.View_Models;
using Mvvm_Product.Services;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using Mvvm_Product.Views;

namespace Mvvm_Product.View_Models
{
    public partial class ProductListViewModel : BaseViewModel
    {
        public ObservableCollection<Product> Products { get; } = new();

        //[ObservableProperty]
        //Product selectedProduct;

        [ObservableProperty]
        bool isRefrshing;

        IProductServices services;
        IConnectivity connectivity;

        public ProductListViewModel(IProductServices services, IConnectivity connectivity)
        {
            this.services = services;
            this.connectivity = connectivity;
            Title = "Product list";
        }

        [RelayCommand]
        async Task GetProductAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                var product = (connectivity.NetworkAccess == NetworkAccess.Internet)
                    ? await services.GetOnLineProductAsync() 
                    : await services.GetOffLineProductAsync();

                if (Products.Any())
                    Products.Clear();

                foreach (var item in product)
                    Products.Add(item);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "Ok");
                throw;
            }
            finally
            {
                IsBusy = false;
                IsRefrshing = false;
            }
        }
        [RelayCommand]
        async Task GoToDetailsAsync(Product selectedProduct)
        {
            if (selectedProduct == null)
                return;

            var data = new Dictionary<string, Object>
            {
                { "ProductKey", selectedProduct }
            };
            await Shell.Current.GoToAsync(nameof(ProductDetailView), true, data);
        }
    }
}

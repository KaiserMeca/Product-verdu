using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mvvm_Product.Models;

namespace Mvvm_Product.View_Models
{
    [QueryProperty(nameof(Product), "ProductKey")]

    public partial class ProductDetailViewModel : ObservableObject
    {

        [ObservableProperty]
        Product product;

    }
}

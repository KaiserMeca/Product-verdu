using Mvvm_Product.View_Models;

namespace Mvvm_Product.Views;

public partial class ProductDetailView : ContentPage
{
	public ProductDetailView(ProductDetailViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
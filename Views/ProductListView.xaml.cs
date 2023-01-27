using Mvvm_Product.View_Models;
namespace Mvvm_Product.Views;

public partial class ProductListView : ContentPage
{
	public ProductListView(ProductListViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
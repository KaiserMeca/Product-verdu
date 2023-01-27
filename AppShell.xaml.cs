using Mvvm_Product.Views;

namespace Mvvm_Product;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(ProductDetailView), typeof(ProductDetailView));
	}
}

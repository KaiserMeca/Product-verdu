using Mvvm_Product.Services;
using Mvvm_Product.Views;
using Mvvm_Product.View_Models;

namespace Mvvm_Product;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		builder.Services.AddSingleton<ProductServices>();
        builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);

        builder.Services.AddSingleton<ProductListViewModel>();
        builder.Services.AddSingleton<ProductListView>();

        builder.Services.AddSingleton<IProductServices, ProductServices>();

		builder.Services.AddTransient<ProductDetailView>();
        builder.Services.AddTransient<ProductDetailViewModel>();

        return builder.Build();
	}
}

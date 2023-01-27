using Mvvm_Product.Models;

namespace Mvvm_Product.Services
{
    public interface IProductServices
    {
        Task<List<Product>> GetOnLineProductAsync();
        Task<List<Product>> GetOffLineProductAsync();

    }
}

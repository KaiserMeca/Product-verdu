using System.Text.Json;
using System.Net.Http.Json;
using Mvvm_Product.Models;

namespace Mvvm_Product.Services
{
    public class ProductServices : IProductServices
    {
        HttpClient httpClient;
        public ProductServices()
        {
            httpClient = new();
        }
        public async Task<List<Product>> GetOnLineProductAsync()
        {
            var response = await httpClient.GetAsync("https://www.jsonkeeper.com/b/LPRG");
            if(response.IsSuccessStatusCode)
            {
                var product = await response.Content.ReadFromJsonAsync<List<Product>>();
                return product;
            }
            return default;
        }
        public async Task<List<Product>> GetOffLineProductAsync()
         {
            using var stream = await FileSystem.OpenAppPackageFileAsync("Product.Json");
            var reader = new StreamReader(stream);
            var content = await reader.ReadToEndAsync();    
            var product = JsonSerializer.Deserialize<List<Product>>(content);
            return product;
        }
    }
}

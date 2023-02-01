using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EAWebApp.Producer;

public class ProductUtil : IProductUtil
{
    private readonly ProductAPI _productApiClient;

    public ProductUtil() => _productApiClient = new ProductAPI("http://eaapi:8001", new HttpClient());

    public async Task<Product> CreateProduct(Product product)
    {
        return await _productApiClient.CreateAsync(product);
    }

    public async Task DeleteProduct(int id)
    {
        await _productApiClient.DeleteAsync(id);
    }

    public async Task<Product> EditProduct(Product product)
    {
        return await _productApiClient.UpdateAsync(product);
    }

    public async Task<ICollection<Product>> GetProduct()
    {
        return await _productApiClient.GetProductsAsync();
    }

    public async Task<Product> GetProductById(int Id)
    {
        return await _productApiClient.GetProductByIdAsync(Id);
    }
}
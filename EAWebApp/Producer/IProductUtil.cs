using System.Collections.Generic;
using System.Threading.Tasks;

namespace EAWebApp.Producer;

public interface IProductUtil
{
    Task<Product> CreateProduct(Product product);
    Task DeleteProduct(int id);
    Task<Product> EditProduct(Product product);
    Task<ICollection<Product>> GetProduct();
    Task<Product> GetProductById(int Id);
}
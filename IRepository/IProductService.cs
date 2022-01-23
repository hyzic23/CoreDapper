using System.Collections.Generic;
using System.Threading.Tasks;
using coredapperapi.Model;

namespace coredapperapi.IRepository
{
    public interface IProductService
    {
         public Task<List<Product>> GetAllProducts();
         public Task<Product> GetProductsById(int id);
         public Task<int> CreateProductAsync(Product product);
         public Task<int> UpdateProductAsync(Product product);
         public Task<int> DeleteProductAsync(Product product);
    }
}
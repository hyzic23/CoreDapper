using System.Collections.Generic;
using System.Threading.Tasks;
using coredapperapi.IRepository;
using coredapperapi.Model;

namespace coredapperapi.Repository
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository; 

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> CreateProductAsync(Product product)
        {
            return await _productRepository.CreateAsync(product);
        }

        public async Task<int> DeleteProductAsync(Product product)
        {
            return await _productRepository.DeleteAsync(product);
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product> GetProductsById(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task<int> UpdateProductAsync(Product product)
        {
            return await _productRepository.UpdateAsync(product);
        }
    }
}
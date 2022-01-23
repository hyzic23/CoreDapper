using System.Collections.Generic;
using System.Threading.Tasks;
using coredapperapi.IRepository;
using coredapperapi.Model;
using Microsoft.AspNetCore.Mvc;

namespace coredapperapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
           return await _productService.GetAllProducts();
        }

         [HttpPost]
         [Route("CreateProducts")]
        public async Task<int> CreateProducts(Product request)
        {
           return await _productService.CreateProductAsync(request);
        }

        [HttpGet]
        [Route("GetProductsById")]
        public async Task<Product> GetProductsById(int id)
        {
           return await _productService.GetProductsById(id);
        }
 
        [HttpDelete]
        [Route("DeleteProduct")]
        public async Task<Product> DeleteProduct(int id)
        {
           return await _productService.GetProductsById(id);
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<int> UpdateProduct(Product product)
        {
           return await _productService.UpdateProductAsync(product);
        }


    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using coredapperapi.IRepository;
using coredapperapi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
//using Serilog;

namespace coredapperapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger logger;
      

        public ProductsController(IProductService productService, 
                                  ILogger<ProductsController> logger)
        {
            _productService = productService;
            this.logger = logger;
        }


        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
           logger.LogInformation($" Calling GetAllProducts API ");
           return await _productService.GetAllProducts();
        }

         [HttpPost]
         [Route("CreateProducts")]
        public async Task<int> CreateProducts(Product request)
        {
           var jsonStr = JsonConvert.SerializeObject(request);
           logger.LogInformation($" Calling CreateProducts API to create Products and payload is { jsonStr }");
           return await _productService.CreateProductAsync(request);
        }

        [HttpGet]
        [Route("GetProductsById")]
        public async Task<Product> GetProductsById(int id)
        {
           logger.LogInformation($" Calling GetProductsById API ");
           return await _productService.GetProductsById(id);
        }
 
        [HttpDelete]
        [Route("DeleteProduct")]
        public async Task<Product> DeleteProduct(int id)
        {
           logger.LogInformation($" Calling DeleteProduct API ");
           return await _productService.GetProductsById(id);
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<int> UpdateProduct(Product product)
        {
           var jsonStr = JsonConvert.SerializeObject(product);
           logger.LogInformation($"Calling UpdateProduct API to create Products and payload is { jsonStr }");
           return await _productService.UpdateProductAsync(product);
        }


    }
}
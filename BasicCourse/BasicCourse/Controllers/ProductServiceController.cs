using BasicCourse.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicCourse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductServiceController : ControllerBase
    {
        private IProductRepository _productRespository;
        
        public ProductServiceController(IProductRepository productRepository)
        {
            _productRespository = productRepository;
        }

        [HttpGet]
        public IActionResult GetAllProducts(string? search, double? from, double? to, string? sortBy, int page = 1) {
            try {
                var result = _productRespository.GetAll(search, from, to, sortBy, page);
                return Ok(result);
            }
            catch {
                return BadRequest("We can't get the product");
            }
        }
    }
}

using BasicCourse.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicCourse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public static List<Product> products = new List<Product>();

        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    return Ok(products);
        //}
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            //linq query
            try
            {
                var product = products.SingleOrDefault(item => item.product_id == Guid.Parse(id));
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(new
                {
                    Success = true,
                    Data = product
                });
            }
            catch {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Create(ProductVM productVM)
        {
            var product = new Product()
            {
                product_id = Guid.NewGuid(),
                name = productVM.name,
                price = productVM.price,
            };
            products.Add(product);
            return Ok(new
            {
                Success = true,
                Data = product
            });
        }

        [HttpPut("{id}")]
        public IActionResult Edit(string id, Product productEdit)
        {
            try
            {
                var product = products.SingleOrDefault(item => item.product_id == Guid.Parse(id));
                if (product == null)
                {
                    return NotFound();
                }
                if (id != product.product_id.ToString())
                {
                    return BadRequest();
                }

                // Update
                product.name = productEdit.name;
                product.price = productEdit.price;

                return Ok(new
                {
                    Success = true,
                    Data = product
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id) {
            try
            {
                var product = products.SingleOrDefault(item => item.product_id == Guid.Parse(id));
                if (product == null)
                {
                    return NotFound();
                }
                if (id != product.product_id.ToString())
                {
                    return BadRequest();
                }

                // Delete
                products.Remove(product);
                return Ok(new
                {
                    Success = true,
                });
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

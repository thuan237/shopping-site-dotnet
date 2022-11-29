using BasicCourse.Data;
using BasicCourse.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BasicCourse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly MyDbContext _context;
        public CategoryController(MyDbContext context) {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllCategory()
        {
            var category_list = _context.Categories.ToList();
            return Ok(
                category_list);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var category = _context.Categories.SingleOrDefault(x=>x.category_id == id);
            if (category != null)
            {
                return Ok(
                category);
            }
            else { return NotFound(); };
        }

        [HttpPost]
        //[Authorize]
        public IActionResult CreateCategoryNew(CategoryModel model) {
            try
            {
                var category = new Category
                {
                    category_name = model.category_name
                };
                _context.Add(category);
                _context.SaveChanges();
                //return Ok(new
                //{
                //    success = true,
                //    Data = category
                //});
                return StatusCode(StatusCodes.Status201Created, category);
            }
            catch { 
                return BadRequest(); 
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategoryById(CategoryModel model, int id)
        {
            var category = _context.Categories.SingleOrDefault(x => x.category_id == id);
            if (category != null)
            {
                category.category_name = model.category_name;
                _context.SaveChanges();
                return NoContent();
            }
            else { return NotFound(); };
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategoryById(int id)
        {
            var category = _context.Categories.SingleOrDefault(x => x.category_id == id);
            if (category != null)
            {
                _context.Remove(category);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK);
                //return Ok(
                //category);
            }
            else { return NotFound(); };
        }
    }
}

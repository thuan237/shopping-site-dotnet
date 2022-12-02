using BasicCourse.Data;
using BasicCourse.Models;
using Microsoft.EntityFrameworkCore;
using static BasicCourse.Models.ProductModel;

namespace BasicCourse.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyDbContext _context;
        public static int PAGE_SIZE { get; set; } = 2;

        public ProductRepository(MyDbContext context) { 
            _context = context;
        }
        public List<_ProductModel> GetAll(string search, double? from, double? to, string? sortBy, int page)
        {
            var all_products = _context.Products.Include(p => p.category).AsQueryable();

            #region filtering
            if (!string.IsNullOrEmpty(search))
            {
                all_products = _context.Products
                .Where(p => p.name.Contains(search));
            }

            if (from.HasValue)
            {
                all_products = all_products.Where(p => p.price >= from);
            }

            if (to.HasValue)
            {
                all_products = all_products.Where(p => p.price <= from);
            }
            #endregion

            #region sorting
            all_products = all_products.OrderBy(p => p.name);
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "product_name_desc": all_products = all_products.OrderBy(p => p.name); break;
                    case "price_asc": all_products = all_products.OrderBy(p => p.price); break;
                    case "price_desc": all_products = all_products.OrderByDescending(p => p.price); break;
                }
            }
            #endregion

            #region paging
            //all_products = all_products.Skip((page-1)*PAGE_SIZE).Take(PAGE_SIZE);

            var result = PaginatedList<BasicCourse.Data.Product>.Create(all_products, page, PAGE_SIZE);
            #endregion

            //var result = all_products.Select(p => new _ProductModel
            //{
            //    product_id = p.product_id,
            //    name = p.name,
            //    price = p.price,
            //    category_name = p.category.category_name
            //});
            //return result.ToList();

            return result.Select(p => new _ProductModel
            {
                product_id = p.product_id,
                name = p.name,
                price = p.price,
                category_name = p.category.category_name
            }).ToList();
        }
    }
}

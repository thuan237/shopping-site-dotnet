using static BasicCourse.Models.ProductModel;

namespace BasicCourse.Services
{
    public interface IProductRepository
    {
        List<_ProductModel> GetAll(string search, double? from, double? to, string? sortBy, int page);
    }
}

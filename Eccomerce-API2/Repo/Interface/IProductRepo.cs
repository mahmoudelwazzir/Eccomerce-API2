using Eccomerce_API2.DTOs.ProductDTO;
using Eccomerce_API2.Models;

namespace Eccomerce_API2.Repo.Interface
{
    public interface IProductRepo : IGenaricRepo<Product>
    {
        Task<IEnumerable<Product>> paginationWithsorting(int pagenumber, int pagesize, bool Sortbyprice);
        Task<Product> secondmostexpinsize(int categoryid);
        Task<IEnumerable<Product>> searchByname(string naem);
    }
}

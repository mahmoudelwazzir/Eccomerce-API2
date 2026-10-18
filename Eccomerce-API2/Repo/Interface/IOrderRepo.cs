using Eccomerce_API2.Models;

namespace Eccomerce_API2.Repo.Interface
{
    public interface IOrderRepo : IGenaricRepo<Order>
    {
        Task<Order> GetOrderByDetails(int id);
    }
}

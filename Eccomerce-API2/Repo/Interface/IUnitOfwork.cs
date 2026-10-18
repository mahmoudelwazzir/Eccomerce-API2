using Eccomerce_API2.Models;

namespace Eccomerce_API2.Repo.Interface
{
    public interface IUnitOfwork
    {
        IGenaricRepo<ApplicationUser> user { get; }
        IGenaricRepo<Category> Categories { get; }
        IOrderRepo Orders { get; }
        IGenaricRepo<OrderItem> OrderItems { get; }
        IProductRepo Products { get; }
        Task save();
    }
}

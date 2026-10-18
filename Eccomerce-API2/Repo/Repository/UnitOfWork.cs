using Eccomerce_API2.Data;
using Eccomerce_API2.Models;
using Eccomerce_API2.Repo.Interface;

namespace Eccomerce_API2.Repo.Repository
{
    public class UnitOfWork : IUnitOfwork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context, IGenaricRepo<ApplicationUser> user, IGenaricRepo<Category> categories, IOrderRepo orders, IGenaricRepo<OrderItem> orderItems, IProductRepo products)
        {
            _context = context;
            this.user = user;
            Categories = categories;
            Orders = orders;
            OrderItems = orderItems;
            Products = products;
        }

        public IGenaricRepo<ApplicationUser> user { get; }

        public IGenaricRepo<Category> Categories {  get; }

        public IOrderRepo Orders { get; }

        public IGenaricRepo<OrderItem> OrderItems { get; }

        public IProductRepo Products { get; }

        public async Task save()
        {
            await _context.SaveChangesAsync();
        }
    }
}

using Eccomerce_API2.Data;
using Eccomerce_API2.Models;
using Eccomerce_API2.Repo.Interface;
using Microsoft.EntityFrameworkCore;

namespace Eccomerce_API2.Repo.Repository
{
    public class OrderRepo : GenaricRepo<Order>, IOrderRepo
    {
        public OrderRepo(AppDbContext context) : base(context)
        {
        }

        public async Task<Order> GetOrderByDetails(int id)
        {
            return await _dbSet      
                .Where(r => r.Id == id)
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync();
        }
    }
}

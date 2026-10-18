using Eccomerce_API2.Data;
using Eccomerce_API2.DTOs.ProductDTO;
using Eccomerce_API2.Models;
using Eccomerce_API2.Repo.Interface;
using Microsoft.EntityFrameworkCore;

namespace Eccomerce_API2.Repo.Repository
{
    public class ProductRepo : GenaricRepo<Product>, IProductRepo
    {
        public ProductRepo(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> searchByname(string naem)
        {
            return await _dbSet.Where(c => c.Name.Contains(naem)).ToListAsync();
        }

        public async Task<Product> secondmostexpinsize(int categoryid)
        {
            return await _dbSet
                .Where(c => c.CategoryId == categoryid)
                .OrderByDescending(p => p.Price)
                .Skip(1)
                .Take(1)
                .FirstOrDefaultAsync();
        }

        async Task<IEnumerable<Product>> IProductRepo.paginationWithsorting(int pagenumber, int pagesize, bool Sortbyprice)
        {
            var q = _dbSet.AsQueryable();
            if (Sortbyprice)
                q = q.OrderBy(p => p.Price);
            else
                q = q.OrderBy(s => s.StockQuantity);
            return await q
                .Skip((pagenumber - 1) * pagesize)
                .Take(pagesize)
                .ToListAsync();
        }
    }
}
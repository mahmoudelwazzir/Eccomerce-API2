using Eccomerce_API2.Data;
using Eccomerce_API2.Repo.Interface;
using Microsoft.EntityFrameworkCore;

namespace Eccomerce_API2.Repo.Repository
{
    public class GenaricRepo<T> : IGenaricRepo<T> where T : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _dbSet;
        public GenaricRepo(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task AddItem(T item)
        {
            await _dbSet.AddAsync(item);
        }

        public async Task DeleteItem(int id)
        {
            var item = await _dbSet.FindAsync(id);
            if(item != null)
            {
                _dbSet.Remove(item);
            }
        }

        public async Task<IEnumerable<T>> GetAllitem()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetItemById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task UpdateItem(T item)
        {
            _dbSet.Update(item);
        }
    }
}

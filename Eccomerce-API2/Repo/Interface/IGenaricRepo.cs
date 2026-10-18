namespace Eccomerce_API2.Repo.Interface
{
    public interface IGenaricRepo<T> where T : class
    {
        Task<IEnumerable<T>> GetAllitem();
        Task<T> GetItemById(int id);
        Task AddItem(T item);
        Task UpdateItem(T item);
        Task DeleteItem(int id);
    }
}

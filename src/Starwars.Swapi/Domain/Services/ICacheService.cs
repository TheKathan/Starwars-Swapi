namespace Starwars.Swapi.Domain.Services
{
    public interface ICacheService
    {
        IEnumerable<T> GetItemsInCache<T>(bool wookiee);
        void SetItemsInCache<T>(IEnumerable<T> list, bool wookiee);
        void SetItemInCache<T>(T item, bool wookiee) where T : IRepositoryModel;
        T? GetItemInCache<T>(int id, bool wookiee);
    }
}

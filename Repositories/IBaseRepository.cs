using System.Linq;

namespace ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Repositories
{
    public interface IBaseRepository<TEntity>
        where TEntity : class
    {
        IQueryable<TEntity> Entities { get; }

        IQueryable<TEntity> Include(params string[] paths);


        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}

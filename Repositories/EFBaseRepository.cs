using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_Bootstrap_Knockout_BookStore.ex.Repositories
{
    public class EFBaseRepository<TContext, TEntity> 
        where TContext : DbContext 
        where TEntity : class
    {
        private readonly TContext _db;

        public EFBaseRepository(TContext dbContext)
        {
            _db = dbContext;
        }

        private DbSet<TEntity> _entities => _db.Set<TEntity>();
        public IQueryable<TEntity> Entities => _entities;

        public void Insert(TEntity entity)
        {
            _entities.Add(entity);
            _db.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _db.Entry<TEntity>(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _entities.Remove(entity);
            _db.SaveChanges();
        }

    }
}

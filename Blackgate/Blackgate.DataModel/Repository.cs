using System.Data.Entity;
using System.Threading.Tasks;

namespace Blackgate.DataModel
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private EfContext<TEntity> context;
        private IDbSet<TEntity> dbSet;

        public IDbSet<TEntity> Entity
        {
            get
            {
                return dbSet;
            }
        }

        public Repository(string nameOrConnectionString)
        {
            context = new EfContext<TEntity>(nameOrConnectionString);
            this.dbSet = context.Set<TEntity>();
        }

        public TEntity GetById<TKey>(TKey id)
        {
            return dbSet.Find(id);
        }

        public void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
        }       

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
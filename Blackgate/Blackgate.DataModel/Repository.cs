using System.Data.Entity;
using System.Threading.Tasks;

namespace Blackgate.DataModel
{
    public class Repository<TEntity> where TEntity : class
    {
        private EfContext<TEntity> context;
        public Repository(string nameOrConnectionString)
        {
            context = new EfContext<TEntity>(nameOrConnectionString);
        }

        public TEntity GetById<TKey>(TKey id)
        {
            return context.Entity.Find(id);
        }

        public void Insert(TEntity entity)
        {
            context.Entity.Add(entity);            
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
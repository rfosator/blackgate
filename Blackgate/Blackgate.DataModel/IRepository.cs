using System.Data.Entity;
using System.Threading.Tasks;

namespace Blackgate.DataModel
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById<TKey>(TKey id);

        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        Task SaveAsync();

        IDbSet<TEntity> Entity { get; }
    }
}

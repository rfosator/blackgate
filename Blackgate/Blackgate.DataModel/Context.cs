using System.Data.Entity;

namespace Blackgate.DataModel
{
    public class EfContext<TEntity> : DbContext where TEntity : class
    {
        public EfContext(string nameOrStringConnection) : base(nameOrStringConnection)
        {
        }

        public IDbSet<TEntity> Entity { get; set; }
    }
}

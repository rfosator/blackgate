using Autofac;
using Blackgate.DataModel;
using System;

namespace Blackgate.API
{
    public class UnitOfWork : IUnitOfWork
    {
        IComponentContext context;
        public UnitOfWork(IComponentContext context)
        {
            this.context = context;
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            try
            {
                return context.Resolve<IRepository<TEntity>>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
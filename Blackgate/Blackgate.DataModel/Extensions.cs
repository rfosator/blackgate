using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Blackgate.DataModel
{
    public static class Extensions
    {
        public static IEnumerable<TEntity> Where<TEntity>(this IRepository<TEntity> repository, 
            Expression<Func<TEntity, bool>> expression) 
            where TEntity : class
        {
            return repository.Entity.Where(expression);
        }

        public static IEnumerable<TResult> Select<TEntity, TResult>(this IRepository<TEntity> repository, 
            Func<TEntity, TResult> selection) 
            where TEntity : class
        {
            return repository.Entity.Select(selection);
        }
    }
}
using System.Threading.Tasks;
using System.Collections.Generic;
using Blackgate.DataModel;
using Blackgate.API.Extensions;

namespace Blackgate.API.Helpers
{
    public static class Helper
    {
        public async static Task<TModel> Get<TModel, TEntity>(
            this IRepository<TEntity> repository, int id) where TEntity : class
        {
            return await Task.Run(() => 
            {
                var course = repository.GetById(id);
                return Mapper.MapTo<TModel, TEntity>(course);
            });
        }

        public async static Task<IEnumerable<TModel>> GetAll<TModel, TEntity>(
            this IRepository<TEntity> repository) where TEntity : class
        {
            return await Task.Run(() => 
            {
                var courses = repository.Select(item => item);

                var enumerable = new List<TModel>();
                foreach (var course in courses)
                {
                    enumerable.Add(Mapper.MapTo<TModel, TEntity>(course));
                }
                return enumerable;
            });
        }

        public async static Task Add<TModel, TEntity>(
            this IRepository<TEntity> repository, TModel model) where TEntity : class
        {
            var entity = Mapper.MapTo<TEntity, TModel>(model);
            repository.Insert(entity);

            await repository.SaveAsync();
        }

        public static async Task Update<TModel, TEntity>(
            this IRepository<TEntity> repository, int id, TModel content) where TEntity : class
        {
            var entity = repository.GetById(id);
            Mapper.CopyTo(content, entity);

            repository.Update(entity);

            await repository.SaveAsync();
        }

        public async static Task Delete<TEntity>(
            this IRepository<TEntity> repository, int id) where TEntity : class
        {
            var entity = repository.GetById(id);
            repository.Delete(entity);

            await repository.SaveAsync();
        }
    }
}
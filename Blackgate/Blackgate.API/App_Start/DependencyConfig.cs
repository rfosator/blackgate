using Autofac;
using Autofac.Integration.WebApi;
using Blackgate.DataModel;
using System.Configuration;
using System.Web.Http;

namespace Blackgate.API
{
    public static class DependencyConfig
    {
        public static void Register()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterApiControllers(typeof(DependencyConfig).Assembly);

            string connection = ConfigurationManager.ConnectionStrings["BlackgateEntities"].ConnectionString;
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>))
                .WithParameter("nameOrConnectionString", connection);

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            var dependencyResolver = new AutofacWebApiDependencyResolver(builder.Build());

            GlobalConfiguration.Configuration.DependencyResolver = dependencyResolver;
        }
    }
}
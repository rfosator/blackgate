using Autofac;
using Autofac.Integration.WebApi;
using System.Web.Http;

namespace Blackgate.API
{
    public static class DependencyConfig
    {
        public static void Register()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterApiControllers(typeof(DependencyConfig).Assembly);

            var dependencyResolver = new AutofacWebApiDependencyResolver(builder.Build());

            GlobalConfiguration.Configuration.DependencyResolver = dependencyResolver;
        }
    }
}
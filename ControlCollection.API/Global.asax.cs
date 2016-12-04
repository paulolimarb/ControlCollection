using System.Web.Http;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using ControlCollection.Infra.Repository;
using ControlCollection.Domain.Interfaces;
using ControlCollection.Domain;

namespace ControlCollection.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Criação do container.
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            // Registrando os tipos
            container.Register<IItemCollectionRepository, ItemCollectionRepository>(Lifestyle.Scoped);
            container.Register<IContactRepository, ContactRepository>(Lifestyle.Scoped);


            // Método de extensão do pacote de integração.
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);


            GlobalConfiguration.Configure(WebApiConfig.Register);

        }
    }
}

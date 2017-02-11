using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using VideoclubAPI.Models.EF;
using VideoclubAPI.Models.EF.Views;
using VideoclubAPI.Repositorio;
using VideoclubAPI.Repositorio.Base;

namespace VideoclubAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

            container.RegisterType<pruebatajamarjrEntities>();

            container.RegisterType<RepositorioPelicula>();

            container.RegisterType<RepositorioCliente>();

            container.RegisterType<RepositorioActor>();

            container.RegisterType<RepositorioActor_Pelicula>();
        }
    }
}
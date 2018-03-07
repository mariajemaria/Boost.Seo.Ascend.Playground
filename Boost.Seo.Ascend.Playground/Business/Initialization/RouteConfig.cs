using System.Web.Routing;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.Web.Routing;

namespace Boost.Seo.Ascend.Playground.Business.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class RouteConfig : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            RegisterRoutes(RouteTable.Routes);
        }

        public void RegisterRoutes(RouteCollection routes)
        {
            // register routes here
        }

        public void Uninitialize(InitializationEngine context)
        {
        }

        public void Preload(string[] parameters)
        {
        }
    }
}
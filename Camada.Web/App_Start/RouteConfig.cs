using System.Web.Mvc;
using System.Web.Routing;

namespace Camada.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: null,
                url: "Pagina{Pagina}",
                defaults: new { controller = "Vitrine", action = "ListarProdutos" }
                
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Produtos", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

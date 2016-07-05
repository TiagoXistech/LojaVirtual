using Camada.Dominio.Repositorio;
using System.Linq;
using System.Web.Mvc;

namespace Camada.Web.Controllers
{
    public class ProdutosController : Controller
    {
        private ProdutosRepositorio Repositorio;
        public ActionResult Index()
        {
            Repositorio = new ProdutosRepositorio();
            var Produtos = Repositorio.Produtos.Take(10);

            return View(Produtos);
        }
    }
}
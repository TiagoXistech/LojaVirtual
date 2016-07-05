using Camada.Dominio.Repositorio;
using System.Linq;
using System.Web.Mvc;

namespace Camada.Web.Controllers
{
    public class VitrineController : Controller
    {
        private ProdutosRepositorio Repositorio;
        public int ProdutoPorPagina = 3;
        public ActionResult ListarProdutos( int Pagina = 1)
        {
            Repositorio = new ProdutosRepositorio();
            var Produtos = Repositorio.Produtos
                .OrderBy(p => p.Descricao)
                .Skip((Pagina - 1) * ProdutoPorPagina)
                .Take(ProdutoPorPagina);

            return View(Produtos);
        }
    }
}
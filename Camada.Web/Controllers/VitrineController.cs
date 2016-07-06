using Camada.Dominio.Repositorio;
using Camada.Web.Models;
using System.Linq;
using System.Web.Mvc;

namespace Camada.Web.Controllers
{
    public class VitrineController : Controller
    {
        private ProdutosRepositorio Repositorio;
        public int ProdutoPorPagina = 3;

        public ViewResult ListarProdutos(string Categoria, int Pagina = 1)
        {
            Repositorio = new ProdutosRepositorio();

            ProdutosViewModel Model = new ProdutosViewModel
            {
                Produtos = Repositorio.Produtos
                .Where(p => Categoria == null || p.Categoria == Categoria)
                .OrderBy(p => p.Descricao)
                .Skip((Pagina - 1) * ProdutoPorPagina)
                .Take(ProdutoPorPagina),

                Paginacao = new Paginacao
                {
                    PaginaAtual = Pagina,
                    ItensPorPagina = ProdutoPorPagina,
                    ItensTotal = Repositorio.Produtos.Count()
                },

                CategoriaAtual = Categoria

            };

            return View(Model);
        }
    }
}
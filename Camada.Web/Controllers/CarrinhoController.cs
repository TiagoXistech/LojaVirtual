using Camada.Dominio.Entidades;
using Camada.Dominio.Repositorio;
using Camada.Web.Models;
using System.Linq;
using System.Web.Mvc;

namespace Camada.Web.Controllers
{
    public class CarrinhoController : Controller
    {
        public ProdutosRepositorio Repositorio;
        private Carrinho ObterCarrinho()
        {
            Carrinho cart = (Carrinho)Session["Carrinho"];
            if (cart == null)
            {
                cart = new Carrinho();
                Session["Carrinho"] = cart;
            }

            return cart;
        }
        public RedirectToRouteResult Adicionar(int ProdutoId, string UrlRetorno)
        {
            Repositorio = new ProdutosRepositorio();
            Produto produto = Repositorio.Produtos.FirstOrDefault(p => p.ProdutoId == ProdutoId);

            if (produto != null)
            {
                ObterCarrinho().AdicionarItem(produto, 1);
            }

            return RedirectToAction("Index", new { UrlRetorno });
        }
        public RedirectToRouteResult Remover(int produtoId, string returnUrl)
        {
            Repositorio = new ProdutosRepositorio();
            Produto produto = Repositorio.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);

            if (produto != null)
            {
                ObterCarrinho().RemevorItem(produto);
            }

            return RedirectToAction("Index", new { returnUrl });
        }
        public ViewResult Index(string returnurl)
        {
            return View(new CarrinhoViewModel
            {
                Carrinho = ObterCarrinho(),
                ReturnUrl = returnurl
            });
        }

    }

}
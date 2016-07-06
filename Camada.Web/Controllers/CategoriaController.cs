using Camada.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Camada.Web.Controllers
{
    public class CategoriaController : Controller
    {
        private ProdutosRepositorio Repositorio = new ProdutosRepositorio();
        public PartialViewResult Menu( string categoria = null)
        {
            ViewBag.CategoriaSelecionada = categoria;

            Repositorio = new ProdutosRepositorio();

              IEnumerable<string> categorias = Repositorio.Produtos
              .Select(c => c.Categoria)
              .Distinct()
              .OrderBy(c => c);

            return PartialView(categorias);
        }
    }
}
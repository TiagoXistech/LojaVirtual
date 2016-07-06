using Camada.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Camada.Web.Models
{
    public class ProdutosViewModel
    {
        public IEnumerable<Produto> Produtos { get; set; }
        public Paginacao Paginacao { get; set; }
        public string CategoriaAtual { get; set; }
    }
}
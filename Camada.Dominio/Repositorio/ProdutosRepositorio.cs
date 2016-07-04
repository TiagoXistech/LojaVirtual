using Camada.Dominio.Entidades;
using System.Collections.Generic;

namespace Camada.Dominio.Repositorio
{
    public class ProdutosRepositorio
    {

        private readonly EfDbContext Context = new EfDbContext();

        public IEnumerable<Produto> Produtos
        {
            get { return Context.Produtos; }
        }


    }
}

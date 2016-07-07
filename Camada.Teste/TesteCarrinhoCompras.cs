using Microsoft.VisualStudio.TestTools.UnitTesting;
using Camada.Dominio.Entidades;
using static Camada.Dominio.Entidades.Carrinho;
using System.Linq;

namespace Camada.Teste
{
    [TestClass]
   public class TesteCarrinhoCompras
    {
        [TestMethod]
        public void AdicionarItensCarrinho()
        {
            Produto Produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Produto1"
            };

            Produto Produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Produto2"
            };

            //Arrange
            Carrinho Carrinho = new Carrinho();
            Carrinho.AdicionarItem(Produto1, 1);
            Carrinho.AdicionarItem(Produto2, 1);

            //Atc
            ItemCarrinho[] Itens = Carrinho.ItensCarrinho.ToArray();

            //Assert
            Assert.AreEqual(Itens.Length, 2);

            Assert.AreEqual(Itens[0].Produto, Produto1);

            Assert.AreEqual(Itens[1].Produto, Produto2);

        }
    }
}

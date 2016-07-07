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

        [TestMethod]
        public void VerificarItensExistentes()
        {
            //Arrange
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

            Carrinho Carrinho = new Carrinho();
            Carrinho.AdicionarItem(Produto1, 1);
            Carrinho.AdicionarItem(Produto2, 1);
            Carrinho.AdicionarItem(Produto1, 10);
           
            //Act
            ItemCarrinho[] resultado = Carrinho.ItensCarrinho
                .OrderBy(c => c.Produto.ProdutoId).ToArray();

            //Assert
            Assert.AreEqual(resultado.Length, 2);



        }

        [TestMethod]
        public void RemoverItensCarrinho()
        {
            Produto Produto1 = new Produto { ProdutoId = 1, Nome = "Produto1" };
            Produto Produto2 = new Produto { ProdutoId = 2, Nome = "Produto2" };

            Carrinho cart = new Carrinho();
            cart.AdicionarItem(Produto1, 3);
            cart.AdicionarItem(Produto2, 2);

            cart.RemevorItem(Produto1);

            Assert.AreEqual(cart.ItensCarrinho.Where(c=>c.Produto == Produto1).Count(), 0);
            Assert.AreEqual(cart.ItensCarrinho.Count(), 1);
        }

        [TestMethod]
        public void CalcularValorTotal()
        {
            Produto Produto1 = new Produto { ProdutoId = 1, Nome = "Produto1", Preco = 10M };
            Produto Produto2 = new Produto { ProdutoId = 2, Nome = "Produto2", Preco = 20M };
            Produto Produto3 = new Produto { ProdutoId = 3, Nome = "Produto3", Preco = 30M };

            Carrinho cart = new Carrinho();
            cart.AdicionarItem(Produto1, 1);
            cart.AdicionarItem(Produto2, 1);
            cart.AdicionarItem(Produto3, 1);

            decimal Resultado = cart.ObterValorTotal();
            Assert.AreEqual(Resultado, 60M);
        }
    }
}

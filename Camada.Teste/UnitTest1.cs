using Camada.Web.HtmlHelpers;
using Camada.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Camada.Teste
{
    [TestClass]
    public class UnitTestLojaVirtual
    {
        [TestMethod]
        public void Take()
        {
            int[] Numeros = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var Resultado = from num in Numeros.Take(5) select num;
            int[] teste = { 5, 4, 1, 3, 9 };
            CollectionAssert.AreEqual(Resultado.ToArray(), teste); 
        }

        [TestMethod]
        public void Skip()
        {
            int[] Numeros = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var Resultado = from num in Numeros.Take(5).Skip(2) select num;
            int[] teste = {1, 3, 9 };
            CollectionAssert.AreEqual(Resultado.ToArray(), teste);
        }

        [TestMethod]
        public void TestePaginacao()
        {
            //Arranger
            HtmlHelper Html = null;

            Paginacao Paginacao = new Paginacao
            {
                PaginaAtual = 2,
                ItensTotal = 28,
                ItensPorPagina = 10
               
            };
     
            Func<int, string> PaginaUrl = i => "Pagina" + i;

            //Act
            MvcHtmlString Resultado = Html.Pagelinks(Paginacao, PaginaUrl);

            //Assert
            Assert.AreEqual(

                @"<a class=""btn btn-default"" href=""Pagina1"">1</a>" +
                @"<a class=""btn btn-default btn-primary selected"" href=""Pagina2"">2</a>" +
                @"<a class=""btn btn-default"" href=""Pagina3"">3</a>", Resultado.ToString()
    
                );

        }
    }
}

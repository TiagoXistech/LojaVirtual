using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

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
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using PagamentoContexto.Domain.Commands;

namespace PagamentoContexto.Tests.Commands
{
    [TestClass]
    public class CriarBoletoAssinaturaCommandTests 
    {
        //  Red, Green, Refactor

        [TestMethod]
        public void DeveRetornarErroQuandoNomeEInvalido()
        {
            var command = new CriarBoletoAssinaturaCommand();
            command.PrimeiroNome = "";

            command.Validar();
            Assert.AreEqual(false, command.Valid);
        }
        
    }
}
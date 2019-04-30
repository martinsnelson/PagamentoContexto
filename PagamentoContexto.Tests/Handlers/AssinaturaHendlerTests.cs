using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PagamentoContexto.Domain.Commands;
using PagamentoContexto.Domain.Enums;
using PagamentoContexto.Domain.Handlers;
using PagamentoContexto.Tests.Mocks;

namespace  PagamentoContexto.Tests.Handlers
{
    [TestClass]
    public class AssinaturaHendlerTests 
    {
        //  Red, Green, Refactor

        [TestMethod]
        public void DeveRetornarErroQuandoDocumentoExiste()
        {
            var handler = new AssinaturaHandler(new FakeAlunoRepository(), new FakeEmailService());
            var command = new CriarBoletoAssinaturaCommand();
            command.PrimeiroNome = "Bruce";
            command.SegundoNome = "Wayne";
            command.Documento = "99999999999";
            command.Email = "hello@balta.io2";
            command.CodigoBarra = "123456789";
            command.BoletoNumero = "1234654987";
            command.PagamentoNumero = "123121";
            command.DataPagamento = DateTime.Now;
            command.DataExpiracao = DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.TotalPago = 60;
            command.Proprietario = "WAYNE CORP";
            command.DocumentoDonoCartao = "12345678911";
            command.TipoDocumentoCartao = EDocumentoTipo.CPF;
            command.EmailDonoCartao = "batman@dc.com";
            command.Rua = "asdas";
            command.Numero = "asdd";
            command.Bairro = "asdasd";
            command.Cidade = "as";
            command.Estado = "as";
            command.Pais = "as";
            command.Cep = "12345678";

            handler.Handle(command);

            Assert.AreEqual(false, handler.Valid);

        }
    }
}
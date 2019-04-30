using PagamentoContexto.Domain.Services;

namespace PagamentoContexto.Tests.Mocks
{
    public class FakeEmailService : IEmailService
    {
        public void Enviar(string para, string email, string assunto, string corpoEmail)
        {
        }
    }
}
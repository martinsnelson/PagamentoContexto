namespace PagamentoContexto.Domain.Services
{
    public interface IEmailService
    {
        void Enviar(string para, string email, string assunto, string corpoEmail);
    }
}
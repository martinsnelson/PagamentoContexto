using Flunt.Validations;
using PagamentoContexto.Shared.ValueObjects;

namespace PagamentoContexto.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string emailEnd)
        {
            EmailEnd = emailEnd;

            AddNotifications(new Contract()
               .Requires()
               .IsEmail(EmailEnd, "Email.EmailEnd", "E-mail inválido")
            );
        }

        public string EmailEnd { get; private set; }
    }
}
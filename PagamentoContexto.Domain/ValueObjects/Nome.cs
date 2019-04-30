using Flunt.Validations;
using PagamentoContexto.Shared.ValueObjects;

namespace PagamentoContexto.Domain.ValueObjects
{
    public class Nome : ValueObject
    {
        public Nome(string primeironome, string segundonome)
        {
            PrimeiroNome = primeironome;
            SegundoNome = segundonome;

            AddNotifications(new Contract()
               .Requires()
               .HasMinLen(PrimeiroNome, 3, "Nome.PrimeiroNome", "Nome deve conter pelo menos 3 caracteres")
               .HasMinLen(SegundoNome, 3, "Nome.SegundoNome", "Sobrenome deve conter pelo menos 3 caracteres")
               .HasMaxLen(SegundoNome, 40, "Nome.PrimeiroNome", "Nome deve conter até 40 caracteres")
            );
        }
        public string PrimeiroNome { get; private set; }
        public string SegundoNome { get; private set; }

        public override string ToString()
        {
            return $"{PrimeiroNome} {SegundoNome}";
        }
    }
}
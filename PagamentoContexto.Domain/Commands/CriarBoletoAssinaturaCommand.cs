using System;
using Flunt.Notifications;
using Flunt.Validations;
using PagamentoContexto.Domain.Enums;
using PagamentoContexto.Shared.Commands;

namespace PagamentoContexto.Domain.Commands
{
    public class CriarBoletoAssinaturaCommand : Notifiable, ICommand
    {
        public string PrimeiroNome { get; set; }
        public string SegundoNome { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }

        public string CodigoBarra { get; set; }
        public string BoletoNumero { get; set; }

        public string PagamentoNumero { get; set; }
        public DateTime DataPagamento { get; set; }
        public DateTime DataExpiracao { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPago { get; set; }
        public string Proprietario { get; set; }
        public string DocumentoDonoCartao { get; set; }
        public EDocumentoTipo TipoDocumentoCartao { get; set; }
        public string EmailDonoCartao { get; set; }

        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string Cep { get; set; }

        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(PrimeiroNome, 3, "Nome.PrimeiroNome", "Nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(PrimeiroNome, 40, "Nome.PrimeiroNome", "Nome deve conter até 40 caracteres")                
            );
        }
    }
}
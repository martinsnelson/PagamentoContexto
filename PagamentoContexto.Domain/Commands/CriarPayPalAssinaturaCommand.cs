using System;
using Flunt.Notifications;
using PagamentoContexto.Domain.Enums;
using PagamentoContexto.Shared.Commands;

namespace PagamentoContexto.Domain.Commands
{
    public class CriarPayPalAssinaturaCommand : Notifiable, ICommand
    {
        public string PrimeiroNome { get; set; }
        public string SegundoNome { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }

        public string CodigoTransacao { get; set; }
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
            throw new NotImplementedException();
        }
    }
}
using System;
using PagamentoContexto.Domain.ValueObjects;

namespace PagamentoContexto.Domain.Entities
{
    public class PayPalPagamento : Pagamento
    {
        public PayPalPagamento(
            string codigoTransacao, DateTime dataPagamento, DateTime dataExpiracao, decimal total, 
            decimal totalPago, string proprietario, Documento documento, Endereco endereco, Email email) 
        : base(dataPagamento, dataExpiracao, total, totalPago, proprietario, documento, endereco, email)
        {
            CodigoTransacao = codigoTransacao;
        }

        public string CodigoTransacao { get; private set; }
    }
}
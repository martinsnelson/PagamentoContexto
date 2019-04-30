using System;
using PagamentoContexto.Domain.ValueObjects;

namespace PagamentoContexto.Domain.Entities
{
    public class BoletoPagamento : Pagamento
    {
        public BoletoPagamento(
            string codigoBarra, 
            string boletoNumero, 
            DateTime dataPagamento, 
            DateTime dataExpiracao, 
            decimal total, 
            decimal totalPago, 
            string proprietario,
            Documento documento, 
            Endereco endereco, 
            Email email) : base(
                dataPagamento, 
                dataExpiracao, 
                total, 
                totalPago, 
                proprietario, 
                documento, 
                endereco, 
                email)
        {
            CodigoBarra = codigoBarra;
            BoletoNumero = boletoNumero;
        }

        public string CodigoBarra { get; private set; }
        public string BoletoNumero { get; private set; }
    }
}
using System;
using PagamentoContexto.Domain.ValueObjects;

namespace PagamentoContexto.Domain.Entities
{
    public class CartaoCreditoPagamento : Pagamento
    {
        public CartaoCreditoPagamento(
            string nomeTitular, 
            string numeroCartao, 
            string ultimoNumeroTransacao, 
            DateTime dataPagamento, 
            DateTime dataExpiracao, 
            decimal total, 
            decimal totalPago, 
            string proprietario, 
            Documento documento, 
            Endereco endereco, 
            Email email) 
        : base(dataPagamento, dataExpiracao, total, totalPago, proprietario, documento, endereco, email)
        {
            NomeTitular = nomeTitular;
            NumeroCartao = numeroCartao;
            UltimoNumeroTransacao = ultimoNumeroTransacao;
        }

        public string NomeTitular { get; private set; }
        public string NumeroCartao { get; private set; }
        public string UltimoNumeroTransacao { get; private set; }
    }
}
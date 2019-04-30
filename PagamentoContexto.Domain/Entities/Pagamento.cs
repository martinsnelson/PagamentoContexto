using System;
using PagamentoContexto.Domain.ValueObjects;
using PagamentoContexto.Shared.Entites;

namespace PagamentoContexto.Domain.Entities
{
    public abstract class Pagamento : Entity
    {
        protected Pagamento(DateTime dataPagamento, DateTime dataExpiracao, decimal total, decimal totalPago, 
        string proprietario, Documento documentodonocartao, Endereco enderecodonocartao, Email emaildonocartao)
        {
            PagamentoNumero = Guid.NewGuid().ToString().Replace("-","").Substring(0,10).ToUpper();
            DataPagamento = dataPagamento;
            DataExpiracao = dataExpiracao;
            Total = total;
            TotalPago = totalPago;
            Proprietario = proprietario;
            DocumentoDonoCartao = documentodonocartao;
            EnderecoDonoCartao = enderecodonocartao;
            EmailDonoCartao = emaildonocartao;
        }

        public string PagamentoNumero { get; private set; }
        public DateTime DataPagamento { get; private set; }
        public DateTime DataExpiracao { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalPago { get; private set; }
        public string Proprietario { get; private set; }
        public Documento DocumentoDonoCartao { get; private set; }
        public Endereco EnderecoDonoCartao { get; private set; }
        public Email EmailDonoCartao { get; private set; }
    }
}
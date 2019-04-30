using System;
using System.Collections.Generic;
using PagamentoContexto.Shared.Entites;

namespace PagamentoContexto.Domain.Entities 
{
    public class Assinatura : Entity
    {
        private IList<Pagamento> _pagamento;
        public Assinatura(DateTime? dataExpiracao)
        {
            DataCriacao = DateTime.Now;
            DataUltimaAtualizacao = DateTime.Now;
            DataExpiracao = dataExpiracao;
            Ativo = true;
            _pagamento = new List<Pagamento>();
        }

        public DateTime DataCriacao { get; private set; }
        public DateTime DataUltimaAtualizacao { get; private set; }
        public DateTime? DataExpiracao { get; private set; }
        public bool Ativo { get; private set; }
        public IReadOnlyCollection<Pagamento> Pagamentos { get; set; }

        public void AdicionarPagamento(Pagamento pagamento)
        {
            _pagamento.Add(pagamento);
        }

        public void AtivarAssinatura()
        {
            Ativo = true;
            DataUltimaAtualizacao = DateTime.Now;
        }

        public void InativarAssinatura()
        {
            Ativo = false;
            DataUltimaAtualizacao = DateTime.Now;
        }
        
    }
}
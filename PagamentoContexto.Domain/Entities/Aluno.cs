using System.Collections.Generic;
using System.Linq;
using PagamentoContexto.Domain.ValueObjects;
using PagamentoContexto.Shared.Entites;

namespace PagamentoContexto.Domain.Entities 
{
    public class Aluno : Entity
    {
        private IList<Assinatura> _assinaturas;
        public Aluno(Nome nome, Documento documento, Email email)
        {
            Nome = nome;
            Documento = documento;
            Email = email;
            _assinaturas =  new List<Assinatura>();

            AddNotifications(nome, documento, email);
        }

        public Nome Nome { get; private set; }
        public Documento Documento { get; private set; }
        public Email Email { get; private set; }
        public Endereco Endereco { get; private set; }
        public IReadOnlyCollection<Assinatura> Assinaturas { get { return _assinaturas.ToArray(); } }

        public void AdicionarAssinatura(Assinatura assinatura)
        {
            foreach(var assi in Assinaturas)
            {
                assi.InativarAssinatura();
            }

            _assinaturas.Add(assinatura);
        }
    }   
}
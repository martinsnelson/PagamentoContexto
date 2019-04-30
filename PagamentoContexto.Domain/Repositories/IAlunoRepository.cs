using PagamentoContexto.Domain.Entities;

namespace PagamentoContexto.Domain.Repositories
{
    public interface IAlunoRepository
    {
        bool DocumentoExiste(string documento);
        bool EmailExiste(string email);
        void CriarAssinatura(Aluno aluno);
    }

}
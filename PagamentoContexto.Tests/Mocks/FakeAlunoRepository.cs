using PagamentoContexto.Domain.Entities;
using PagamentoContexto.Domain.Repositories;

namespace PagamentoContexto.Tests.Mocks 
{
    public class FakeAlunoRepository : IAlunoRepository
    {
        public void CriarAssinatura(Aluno aluno)
        {
            throw new System.NotImplementedException();
        }

        public bool DocumentoExiste(string documento)
        {
            if(documento == "99999999999")
                return true;

            return false;
        }

        public bool EmailExiste(string email)
        {
            if(email == "nelson@nelson.com.br")
                return true;

            return false;
        }
    }
}
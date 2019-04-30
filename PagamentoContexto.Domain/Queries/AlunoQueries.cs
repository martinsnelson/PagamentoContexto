using System;
using System.Linq.Expressions;
using PagamentoContexto.Domain.Entities;

namespace PagamentoContexto.Domain.Queries 
{
    public static class AlunoQueries
    {
        public static Expression<Func<Aluno, bool>> ObterAlunoInfo(string documento)
        {
            return x => x.Documento.Numero == documento;
        }
    }
}
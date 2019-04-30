using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PagamentoContexto.Domain.Entities;
using PagamentoContexto.Domain.Enums;
using PagamentoContexto.Domain.Queries;
using PagamentoContexto.Domain.ValueObjects;

namespace PagamentoContexto.Tests.Queries 
{
    [TestClass]
    public class AlunoQueriesTests
    {
        // Red, Green, Refactor
        private IList<Aluno> _students;

        public AlunoQueriesTests()
        {
            _students = new List<Aluno>();
            for (var i = 0; i <= 10; i++)
            {
                _students.Add(new Aluno(
                    new Nome("Aluno", i.ToString()),
                    new Documento("1111111111" + i.ToString(), EDocumentoTipo.CPF),
                    new Email(i.ToString() + "@martins.io")
                ));
            }
        }

        [TestMethod]
        public void ShouldReturnNullWhenDocumentNotExists()
        {
            var exp = AlunoQueries.ObterAlunoInfo("12345678911");
            var studn = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(null, studn);
        }

        [TestMethod]
        public void ShouldReturnStudentWhenDocumentExists()
        {
            var exp = AlunoQueries.ObterAlunoInfo("11111111111");
            var studn = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreNotEqual(null, studn);
        }

    }
}
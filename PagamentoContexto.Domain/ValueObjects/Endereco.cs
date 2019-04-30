using PagamentoContexto.Shared.ValueObjects;

namespace PagamentoContexto.Domain.ValueObjects
{
    public class Endereco : ValueObject
    {
        public Endereco(string rua, string numero, string bairro, string cidade, string estado, string pais, string cep)
        {
            Rua = rua;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Pais = pais;
            Cep = cep;
        }

        public string Rua { get; private set; }
        public string Numero { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string Pais { get; private set; }
        public string Cep { get; private set; }
    }
}
using Flunt.Validations;
using PagamentoContexto.Domain.Enums;
using PagamentoContexto.Shared.ValueObjects;

namespace PagamentoContexto.Domain.ValueObjects
{
    public class Documento : ValueObject
    {
        public Documento(string numero, EDocumentoTipo tipo)
        {
            Numero = numero;
            Tipo = tipo;

            AddNotifications(new Contract()
                .Requires()
                 .IsTrue(Validar(), "Documento.Numero", "Documento inválido")
            );
        }

        public string Numero { get; private set; }
        public EDocumentoTipo Tipo { get; private set; }

        private bool Validar()
        {
            if(Tipo == EDocumentoTipo.CNPJ && Numero.Length == 14)
                return true;

            if(Tipo == EDocumentoTipo.CPF && Numero.Length == 11)
                return true;

            return false;
        }
    }
}
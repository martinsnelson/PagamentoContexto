using PagamentoContexto.Shared.Commands;

namespace  PagamentoContexto.Domain.Commands
{
    public class CommandResult : ICommandResult
    {
        public CommandResult()
        {
        }
        public CommandResult(bool sucesso, string mensagem)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
        }

        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
    }
}
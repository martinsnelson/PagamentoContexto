using PagamentoContexto.Shared.Commands;

namespace PagamentoContexto.Shared.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
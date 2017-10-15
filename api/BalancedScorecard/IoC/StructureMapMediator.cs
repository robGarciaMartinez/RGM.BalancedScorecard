using BalancedScorecard.Kernel.Commands;
using StructureMap;

namespace BalancedScorecard.Api.IoC
{
    public class StructureMapMediator :
        ICommandDispatcherDependencyContainer
    {
        public readonly IContainer _container;

        public StructureMapMediator(IContainer container)
        {
            _container = container;
        }

        public ICommandHandler<TCommand> GetCommandHandler<TCommand>() where TCommand : ICommand
        {
            return _container.GetInstance<ICommandHandler<TCommand>>();
        }
    }
}

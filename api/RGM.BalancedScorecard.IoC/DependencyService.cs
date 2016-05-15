namespace RGM.BalancedScorecard.IoC
{
    using RGM.BalancedScorecard.Domain.Dependencies;
    using RGM.BalancedScorecard.SharedKernel.Domain.Commands;

    using StructureMap;

    public class DependencyService : IDomainDependencyService
    {
        private readonly IContainer container;

        public DependencyService(IContainer container)
        {
            this.container = container;
        }

        public ICommandHandler<TCommand> GetCommandHandler<TCommand>() where TCommand : ICommand
        {
            return
                this.container.ForGenericType(typeof(ICommandHandler<>))
                    .WithParameters(typeof(TCommand))
                    .GetInstanceAs<ICommandHandler<TCommand>>();
        }
    }
}

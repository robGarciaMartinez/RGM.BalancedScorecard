namespace RGM.BalancedScorecard.IoC
{
    using System.Collections.Generic;

    using SharedKernel.DependencyContainer;
    using SharedKernel.Domain.Commands;
    using SharedKernel.Domain.Validation;

    using StructureMap;

    public class CustomDependencyContainer : IDependencyContainer
    {
        private readonly IContainer container;

        public CustomDependencyContainer(IContainer container)
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

        public IValidator<TCommand> GetValidator<TCommand>() where TCommand : ICommand
        {
            return
                this.container.ForGenericType(typeof(IValidator<>))
                    .WithParameters(typeof(TCommand))
                    .GetInstanceAs<IValidator<TCommand>>();
        }

        public IEnumerable<ISpecification<TCommand>> GetSpecifications<TCommand>() where TCommand : ICommand
        {
            return this.container.GetAllInstances<ISpecification<TCommand>>();
        }
    }
}

using System;
using static RHS.Components.SharedKernel.KernelEnums;

namespace BalancedScorecard.Kernel.Domain
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; }

        public DomainState State { get; private set; }

        public void SetState(DomainState state)
        {
            if (State == DomainState.Added)
            {
                return;
            }

            State = state;
        }

        public void InitializeState()
        {
            State = DomainState.Unchanged;
        }

        public virtual void Delete()
        {
            State = DomainState.Deleted;
        }
    }
}

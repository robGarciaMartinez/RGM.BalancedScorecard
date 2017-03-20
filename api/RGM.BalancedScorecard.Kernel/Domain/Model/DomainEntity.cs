using System;

namespace RGM.BalancedScorecard.Kernel.Domain.Model
{
    public abstract class DomainEntity
    {
        protected DomainEntity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; protected set; }
    }
}
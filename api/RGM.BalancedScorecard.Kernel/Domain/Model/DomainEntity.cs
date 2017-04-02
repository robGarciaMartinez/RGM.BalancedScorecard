using System;

namespace RGM.BalancedScorecard.Kernel.Domain.Model
{
    public abstract class DomainEntity
    {
        public Guid Id { get; set; }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}
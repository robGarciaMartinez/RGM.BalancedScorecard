using System;

namespace BalancedScorecard.Domain.Commands
{
    public class BaseAggregateRootCommand : BaseCommand
    {
        public Guid Id { get; set; }
    }
}

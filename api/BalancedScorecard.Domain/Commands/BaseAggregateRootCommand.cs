using System;
using System.ComponentModel.DataAnnotations;

namespace BalancedScorecard.Domain.Commands
{
    public class BaseAggregateRootCommand : BaseCommand
    {
        [Required]
        public Guid? Id { get; set; }
    }
}

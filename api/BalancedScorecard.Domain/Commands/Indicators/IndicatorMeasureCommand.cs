using BalancedScorecard.Domain.Model.Indicators.Values;
using System;
using System.ComponentModel.DataAnnotations;

namespace BalancedScorecard.Domain.Commands.Indicators
{
    public class IndicatorMeasureCommand : BaseCommand
    {
        public Guid IndicatorMeasureId { get; set; }

        public Guid IndicatorId { get; set; }

        [Required]
        public DateTime? Date { get; set; }

        [Required]
        public IIndicatorValue RealValue { get; set; }

        [Required]
        public IIndicatorValue ObjectiveValue { get; set; }

        public string Notes { get; set; }
    }
}

using RGM.BalancedScorecard.Domain.Model.Indicators.Values;
using System;
using System.ComponentModel.DataAnnotations;

namespace RGM.BalancedScorecard.Domain.Commands.Indicators
{
    public class CreateIndicatorMeasureCommand : BaseCommand
    {
        [Required]
        public Guid Id { get; set; }

        public Guid IndicatorId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public IIndicatorValue Record { get; set; }

        [Required]
        public IIndicatorValue Objective { get; set; }

        public string Notes { get; set; }
    }
}

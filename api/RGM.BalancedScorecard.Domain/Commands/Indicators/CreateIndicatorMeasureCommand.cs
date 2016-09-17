namespace RGM.BalancedScorecard.Domain.Commands.Indicators
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using SharedKernel.Domain.Commands;
    using Model.Indicators.Values;

    public class CreateIndicatorMeasureCommand : ICommand
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

namespace RGM.BalancedScorecard.Domain.Commands.Indicators
{
    using Enums;
    using RGM.BalancedScorecard.SharedKernel.Domain.Commands;

    using System.ComponentModel.DataAnnotations;

    using System;

    public class IndicatorCommand : ICommand
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Unit { get; set; }

        [Required]
        public IndicatorEnum.PeriodicityType Periodicity { get; set; }

        [Required]
        public IndicatorEnum.ComparisonValueType ComparisonValue { get; set; }

        [Required]
        public IndicatorEnum.ObjectValueType ObjectValue { get; set; }

        [Required]
        public Guid IndicatorTypeId { get; set; }

        [Required]
        public Guid ResponsibleId { get; set; }

        public int? FulfillmentRate { get; set; }

        [Required]
        public bool Cumulative { get; set; }
    }
}

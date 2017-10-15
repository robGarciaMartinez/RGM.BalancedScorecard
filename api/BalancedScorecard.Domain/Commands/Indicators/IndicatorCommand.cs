using BalancedScorecard.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace BalancedScorecard.Domain.Commands.Indicators
{
    public class IndicatorCommand : BaseCommand
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Unit { get; set; }

        [Required]
        public IndicatorEnum.PeriodicityType Periodicity { get; set; }

        [Required]
        public IndicatorEnum.ComparisonType ComparisonType { get; set; }

        [Required]
        public IndicatorEnum.IndicatorValueType IndicatorValueType { get; set; }

        [Required]
        public Guid IndicatorTypeId { get; set; }

        [Required]
        public Guid ResponsibleId { get; set; }

        public int? FulfillmentRate { get; set; }

        [Required]
        public bool Cumulative { get; set; }
    }
}

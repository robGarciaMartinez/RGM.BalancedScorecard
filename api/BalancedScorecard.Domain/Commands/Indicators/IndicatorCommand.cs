using BalancedScorecard.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace BalancedScorecard.Domain.Commands.Indicators
{
    public class IndicatorCommand : BaseAggregateRootCommand
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Code { get; set; }

        public string Unit { get; set; }

        [Required]
        public IndicatorEnum.PeriodicityType? PeriodicityType { get; set; }

        [Required]
        public IndicatorEnum.ComparisonType? ComparisonType { get; set; }

        [Required]
        public IndicatorEnum.IndicatorValueType? IndicatorValueType { get; set; }

        public Guid? IndicatorTypeId { get; set; }

        public Guid? ResponsibleId { get; set; }

        public int? FulfillmentRate { get; set; }

        public bool Cumulative { get; set; }
    }
}

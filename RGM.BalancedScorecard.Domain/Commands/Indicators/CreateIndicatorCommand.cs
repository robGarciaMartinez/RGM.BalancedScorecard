namespace RGM.BalancedScorecard.Domain.Commands.Indicators
{
    using System;

    using RGM.BalancedScorecard.SharedKernel.Domain.Commands;

    public class CreateIndicatorCommand : ICommand
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public string Code { get; set; }

        public string Unit { get; set; }

        public int Periodicity { get; set; }

        public int ComparisonValue { get; set; }

        public int ObjectValue { get; set; }

        public Guid IndicatorTypeId { get; set; }

        public Guid ResponsibleId { get; set; }

        public int? FulfillmentRate { get; set; }

        public bool Cumulative { get; set; }
    }
}

namespace RGM.BalancedScorecard.Domain.Model.Indicators.Base
{
    using System;

    using RGM.BalancedScorecard.Domain.Enums;
    using RGM.BalancedScorecard.SharedKernel.Domain;
    using RGM.BalancedScorecard.SharedKernel.Domain.Model;

    public class BaseIndicator : AggregateRoot<Guid>
    {
        public BaseIndicator(
            Guid id,
            string name,
            string description,
            DateTime startDate,
            string code,
            string unit,
            IndicatorEnum.PeriodicityType periodicity,
            IndicatorEnum.ComparisonValueType comparisonValue,
            IndicatorEnum.ObjectValueType objectValue,
            Guid indicatorTypeId,
            Guid responsibleId,
            int? fulfillmentRate,
            bool cumulative)
            : base(id)
        {
            this.Name = name;
            this.Description = description;
            this.StartDate = startDate;
            this.Code = code;
            this.Unit = unit;
            this.Periodicity = periodicity;
            this.ComparisonValue = comparisonValue;
            this.ObjectValue = objectValue;
            this.IndicatorTypeId = indicatorTypeId;
            this.ResponsibleId = responsibleId;
            this.FulfillmentRate = fulfillmentRate;
            this.Cumulative = cumulative;
        }

        public BaseIndicator(Guid id) : base(id)
        {
        }

        /// <summary>
        ///     Gets the name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        ///     Gets the description.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        ///     Gets the start date.
        /// </summary>
        public DateTime StartDate { get; private set; }

        /// <summary>
        ///     Gets the code.
        /// </summary>
        public string Code { get; private set; }

        /// <summary>
        ///     Gets the unit.
        /// </summary>
        public string Unit { get; private set; }

        /// <summary>
        ///     Gets the periodicity.
        /// </summary>
        public IndicatorEnum.PeriodicityType Periodicity { get; private set; }

        /// <summary>
        ///     Gets the comparison value.
        /// </summary>
        public IndicatorEnum.ComparisonValueType ComparisonValue { get; private set; }

        /// <summary>
        ///     Gets the object value.
        /// </summary>
        public IndicatorEnum.ObjectValueType ObjectValue { get; private set; }

        /// <summary>
        ///     Gets the indicator type id.
        /// </summary>
        public Guid IndicatorTypeId { get; private set; }

        /// <summary>
        ///     Gets the responsible id.
        /// </summary>
        public Guid ResponsibleId { get; private set; }

        /// <summary>
        ///     Gets the fulfillment rate.
        /// </summary>
        public int? FulfillmentRate { get; private set; }

        /// <summary>
        ///     Gets the cumulative.
        /// </summary>
        public bool Cumulative { get; private set; }

        protected override void Validate()
        {
        }
    }
}
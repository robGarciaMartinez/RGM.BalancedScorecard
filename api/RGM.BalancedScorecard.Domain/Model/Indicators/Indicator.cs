namespace RGM.BalancedScorecard.Domain.Model.Indicators
{
    using System;
    using System.Collections.Generic;

    using RGM.BalancedScorecard.Domain.Enums;
    using RGM.BalancedScorecard.Domain.Events.Indicators;
    using RGM.BalancedScorecard.Domain.Services.Interfaces;
    using RGM.BalancedScorecard.SharedKernel.Domain.Model;
    using RGM.BalancedScorecard.SharedKernel.Exceptions;

    public class Indicator : AggregateRoot<Guid>
    {
        public Indicator(
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
            bool cumulative,
            Guid id)
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

        public Indicator()
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

        /// <summary>
        ///     Gets the measures.
        /// </summary>
        public List<IndicatorMeasure> Measures { get; private set; }

        /// <summary>
        ///     Gets the state.
        /// </summary>
        public IndicatorEnum.State State { get; private set; }

        public void Create(IIndicatorStateCalculator stateCalculator)
        {
            this.State = stateCalculator.Calculate(this);
            this.AddEvent(new IndicatorCreatedEvent { IndicatorId = this.Id });
        }

        #region Measure

        public void SetMeasures(List<IndicatorMeasure> measures)
        {
            this.Measures = measures;
        }

        public void AddMeasure(IndicatorMeasure measure)
        {
            this.Measures.Add(measure);
        }

        public void UpdateMeasure(IndicatorMeasure measure)
        {
            var measureIndex = this.Measures.FindIndex(m => m.Id == measure.Id);
            if (measureIndex == -1)
            {
                throw new ItemNotFoundException("Cannot find a measure with the given id");
            }

            this.Measures[measureIndex] = measure;
        }

        public void DeleteMeasure(IndicatorMeasure measure)
        {
            var measureIndex = this.Measures.FindIndex(m => m.Id == measure.Id);
            if (measureIndex == -1)
            {
                throw new ItemNotFoundException("Cannot find a measure with the given id");
            }

            this.Measures.RemoveAt(measureIndex);
        }

        #endregion
    }
}
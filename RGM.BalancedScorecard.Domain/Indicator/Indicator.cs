﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Indicator.cs" company="RGM">
//   RGM
// </copyright>
// <summary>
//   Defines the Indicator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RGM.BalancedScorecard.Domain.Indicator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using RGM.BalancedScorecard.Domain.User;
    using RGM.BalancedScorecard.SharedKernel.Domain;

    /// <summary>
    /// The indicator.
    /// </summary>
    public class Indicator : AggregateRoot<Guid?>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Indicator"/> class.
        /// </summary>        
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="code">The code.</param>
        /// <param name="unit">The unit.</param>
        /// <param name="periodicity">The periodicity.</param>
        /// <param name="comparisonValue">The comparison value.</param>
        /// <param name="objectValue">The object value.</param>
        /// <param name="indicatorTypeId">The indicator type id.</param>
        /// <param name="responsibleId">The responsible id.</param>
        /// <param name="fulfillmentRate">The fulfillment rate.</param>
        /// <param name="cumulative">The cumulative.</param>
        /// <param name="measures">The measures.</param>
        /// <param name="responsible">The responsible</param>
        /// <param name="id">The id.</param>
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
            List<IndicatorMeasure> measures,
            User responsible,
            Guid? id = null)
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
            this.Measures = measures;
            this.Responsible = responsible;
            this.Cumulative = cumulative;
        }

        public Indicator(Guid id)
            : base(id)
        {
            
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the description.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Gets the start date.
        /// </summary>
        public DateTime StartDate { get; private set; }

        /// <summary>
        /// Gets the code.
        /// </summary>
        public string Code { get; private set; }

        /// <summary>
        /// Gets the unit.
        /// </summary>
        public string Unit { get; private set; }

        /// <summary>
        /// Gets the periodicity.
        /// </summary>
        public IndicatorEnum.PeriodicityType Periodicity { get; private set; }

        /// <summary>
        /// Gets the comparison value.
        /// </summary>
        public IndicatorEnum.ComparisonValueType ComparisonValue { get; private set; }

        /// <summary>
        /// Gets the object value.
        /// </summary>
        public IndicatorEnum.ObjectValueType ObjectValue { get; private set; }

        /// <summary>
        /// Gets the indicator type id.
        /// </summary>
        public Guid IndicatorTypeId { get; private set; }

        /// <summary>
        /// Gets the responsible id.
        /// </summary>
        public Guid ResponsibleId { get; private set; }

        /// <summary>
        /// Gets the fulfillment rate.
        /// </summary>
        public int? FulfillmentRate { get; private set; }

        /// <summary>
        /// Gets the cumulative.
        /// </summary>
        public bool Cumulative { get; private set; }

        /// <summary>
        /// Gets the disabled.
        /// </summary>
        public bool Disabled { get; private set; }

        /// <summary>
        /// Gets the measures.
        /// </summary>
        public List<IndicatorMeasure> Measures { get; private set; }

        /// <summary>
        /// Gets the responsible.
        /// </summary>
        public User Responsible { get; private set; }

        /// <summary>
        /// Gets the state.
        /// </summary>
        public IndicatorEnum.State State => this.CalculateState();

        /// <summary>
        /// Gets the last measure.
        /// </summary>
        public IndicatorMeasure LastMeasure => this.Measures.OrderByDescending(m => m.Date).FirstOrDefault();

        /// <summary>
        /// The validate.
        /// </summary>
        protected override void Validate()
        {
        }

        /// <summary>
        /// The calculate state.
        /// </summary>
        /// <returns>
        /// The <see cref="State"/>.
        /// </returns>
        private IndicatorEnum.State CalculateState()
        {
            var lastMeasure = this.LastMeasure;

            if (lastMeasure?.RealValue == null)
            {
                return IndicatorEnum.State.Grey;
            }

            if (lastMeasure.Date.AddMonths((int)this.Periodicity) < DateTime.Today)
            {
                return IndicatorEnum.State.Grey;
            }

            var targetValueRate = (double)(this.FulfillmentRate.HasValue ? decimal.Divide(this.FulfillmentRate.Value, 100) : 1);

            switch (this.ComparisonValue)
            {
                case IndicatorEnum.ComparisonValueType.Equal:
                    return lastMeasure.RealValue.Value.Equals(lastMeasure.TargetValue)
                               ? IndicatorEnum.State.Green
                               : IndicatorEnum.State.Red;
                case IndicatorEnum.ComparisonValueType.Greater:
                    return lastMeasure.RealValue.Value > lastMeasure.TargetValue
                               ? IndicatorEnum.State.Green
                               : (lastMeasure.RealValue.Value
                                  > (lastMeasure.TargetValue - (lastMeasure.TargetValue * targetValueRate))
                                      ? IndicatorEnum.State.Yellow
                                      : IndicatorEnum.State.Red);
                case IndicatorEnum.ComparisonValueType.Smaller:
                    return lastMeasure.RealValue.Value < lastMeasure.TargetValue
                               ? IndicatorEnum.State.Green
                               : (lastMeasure.RealValue.Value
                                  < (lastMeasure.TargetValue + (lastMeasure.TargetValue * targetValueRate))
                                      ? IndicatorEnum.State.Yellow
                                      : IndicatorEnum.State.Red);
                default:
                    return IndicatorEnum.State.Grey;
            }
        }

        public void Create()
        {
            this.Id = Guid.NewGuid();
            this.Validate();
        }

        public void Update()
        {
            this.Validate();
        }

        public void Delete()
        {
            this.Disabled = true;
        }
    }
}
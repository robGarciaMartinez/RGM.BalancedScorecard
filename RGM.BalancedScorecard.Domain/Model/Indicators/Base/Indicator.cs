// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Indicator.cs" company="RGM">
//   RGM
// </copyright>
// <summary>
//   Defines the Indicator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RGM.BalancedScorecard.Domain.Model.Indicators.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using RGM.BalancedScorecard.Domain.Enums;
    using RGM.BalancedScorecard.Domain.Model.Indicators.Measures;

    /// <summary>
    ///     The indicator.
    /// </summary>
    public abstract class Indicator<TValue> : BaseIndicator
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Indicator{TValue}" /> class.
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
        /// <param name="id">The id.</param>
        protected Indicator(
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
            : base(
                id,
                name,
                description,
                startDate,
                code,
                unit,
                periodicity,
                comparisonValue,
                objectValue,
                indicatorTypeId,
                responsibleId,
                fulfillmentRate,
                cumulative)
        {
        }

        /// <summary>
        ///     Gets the measures.
        /// </summary>
        public List<IndicatorMeasure<TValue>> Measures { get; set; }

        /// <summary>
        ///     Gets the last measure.
        /// </summary>
        public IndicatorMeasure<TValue> LastMeasure => this.Measures.OrderByDescending(m => m.Date).FirstOrDefault();

        /// <summary>
        ///     Gets the state.
        /// </summary>
        public IndicatorEnum.State State => this.CalculateState();

        /// <summary>
        ///     The validate.
        /// </summary>
        protected override void Validate()
        {
        }

        /// <summary>
        ///     The calculate state.
        /// </summary>
        /// <returns>
        ///     The <see cref="State" />.
        /// </returns>
        private IndicatorEnum.State CalculateState()
        {
            //var lastMeasure = this.LastMeasure;

            //if (lastMeasure?.RealValue == null)
            //{
            //    return IndicatorEnum.State.Grey;
            //}

            //if (lastMeasure.Date.AddMonths((int)this.Periodicity) < DateTime.Today)
            //{
            //    return IndicatorEnum.State.Grey;
            //}

            //var targetValueRate =
            //    (double)(this.FulfillmentRate.HasValue ? decimal.Divide(this.FulfillmentRate.Value, 100) : 1);

            //switch (this.ComparisonValue)
            //{
            //    case IndicatorEnum.ComparisonValueType.Equal:
            //        return lastMeasure.RealValue.Value.Equals(lastMeasure.TargetValue)
            //                   ? IndicatorEnum.State.Green
            //                   : IndicatorEnum.State.Red;
            //    case IndicatorEnum.ComparisonValueType.Greater:
            //        return lastMeasure.RealValue.Value > lastMeasure.TargetValue
            //                   ? IndicatorEnum.State.Green
            //                   : (lastMeasure.RealValue.Value
            //                      > lastMeasure.TargetValue - lastMeasure.TargetValue * targetValueRate
            //                          ? IndicatorEnum.State.Yellow
            //                          : IndicatorEnum.State.Red);
            //    case IndicatorEnum.ComparisonValueType.Smaller:
            //        return lastMeasure.RealValue.Value < lastMeasure.TargetValue
            //                   ? IndicatorEnum.State.Green
            //                   : (lastMeasure.RealValue.Value
            //                      < lastMeasure.TargetValue + lastMeasure.TargetValue * targetValueRate
            //                          ? IndicatorEnum.State.Yellow
            //                          : IndicatorEnum.State.Red);
            //    default:
            //        return IndicatorEnum.State.Grey;
            //}
            return IndicatorEnum.State.Grey;
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
                
        }
    }
}
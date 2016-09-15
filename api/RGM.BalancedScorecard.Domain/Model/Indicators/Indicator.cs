namespace RGM.BalancedScorecard.Domain.Model.Indicators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using RGM.BalancedScorecard.Domain.Enums;
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

        public Indicator() { }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public DateTime StartDate { get; private set; }

        public string Code { get; private set; }

        public string Unit { get; private set; }

        public IndicatorEnum.PeriodicityType Periodicity { get; private set; }

        public IndicatorEnum.ComparisonValueType ComparisonValue { get; private set; }

        public IndicatorEnum.ObjectValueType ObjectValue { get; private set; }

        public Guid IndicatorTypeId { get; private set; }

        public Guid ResponsibleId { get; private set; }

        public int? FulfillmentRate { get; private set; }

        public bool Cumulative { get; private set; }

        public List<IndicatorMeasure> Measures { get; private set; }

        public IndicatorEnum.State State { get; private set; }

        public string MyFancyNewColumn { get; private set; }

        public string xxx { get; private set; }

        public void Update(string name,
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

        public void SetState(IndicatorEnum.State state)
        {
            this.State = state;
        }

        #region Measures

        public List<IndicatorMeasure> GetMeasures(List<IndicatorMeasure> measures)
        {
            return this.Measures;
        }

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

        public bool HasAnyMeasures()
        {
            return this.Measures != null && this.Measures.Any();
        }

        #endregion
    }
}
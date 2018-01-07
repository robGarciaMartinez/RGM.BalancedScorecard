using BalancedScorecard.Domain.Enums;
using BalancedScorecard.Domain.Events.Indicators;
using BalancedScorecard.Domain.Model.Indicators.Values;
using BalancedScorecard.Kernel.Domain;
using BalancedScorecard.Kernel.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BalancedScorecard.Domain.Model.Indicators
{
    public class Indicator : AggregateRoot
    {
        public Indicator(
            Guid id,
            string name, 
            string description, 
            string code, 
            string unit, 
            IndicatorEnum.PeriodicityType periodicityType, 
            IndicatorEnum.ComparisonType comparisonType, 
            IndicatorEnum.IndicatorValueType indicatorValueType, 
            Guid? indicatorTypeId, 
            Guid? responsibleId, 
            int? fulfillmentRate, 
            bool cumulative)
        {
            Id = id;
            Name = name;
            Description = description;
            Code = code;
            Unit = unit;
            PeriodicityType = periodicityType;
            ComparisonType = comparisonType;
            IndicatorValueType = indicatorValueType;
            IndicatorTypeId = indicatorTypeId;
            ResponsibleId = responsibleId;
            FulfillmentRate = fulfillmentRate;
            Cumulative = cumulative;
            Status = IndicatorEnum.Status.Grey;
            AddEvent(
                new IndicatorCreatedEvent
                {
                    IndicatorId = Id,
                    Name = Name,
                    Description = Description,
                    Code = Code,
                    Unit = Unit,
                    PeriodicityType = PeriodicityType,
                    ComparisonType = ComparisonType,
                    IndicatorValueType = IndicatorValueType,
                    IndicatorTypeId = IndicatorTypeId,
                    ResponsibleId = ResponsibleId,
                    FulfillmentRate = FulfillmentRate,
                    Cumulative = Cumulative,
                    IndicatorStatus = Status
                });
        }

        public Indicator() { }

        [JsonProperty]
        public string Name { get; private set; }

        [JsonProperty]
        public string Description { get; private set; }

        [JsonProperty]
        public string Code { get; private set; }

        [JsonProperty]
        public string Unit { get; private set; }

        [JsonProperty]
        public IndicatorEnum.PeriodicityType PeriodicityType { get; private set; }

        [JsonProperty]
        public IndicatorEnum.ComparisonType ComparisonType { get; private set; }

        [JsonProperty]
        public IndicatorEnum.IndicatorValueType IndicatorValueType { get; private set; }

        [JsonProperty]
        public Guid? IndicatorTypeId { get; private set; }

        [JsonProperty]
        public Guid? ResponsibleId { get; private set; }

        [JsonProperty]
        public int? FulfillmentRate { get; private set; }

        [JsonProperty]
        public bool Cumulative { get; private set; }

        [JsonProperty]
        public IndicatorEnum.Status Status { get; private set; }

        [JsonProperty]
        public List<IndicatorMeasure> Measures { get; private set; }
    
        public void Update(
            string name,
            string description,
            string code,
            string unit,
            IndicatorEnum.PeriodicityType periodicityType,
            IndicatorEnum.ComparisonType comparisonType,
            IndicatorEnum.IndicatorValueType indicatorValueType,
            Guid? indicatorTypeId,
            Guid? responsibleId,
            int? fulfillmentRate,
            bool cumulative)
        {
            Name = name;
            Description = description;
            Code = code;
            Unit = unit;
            PeriodicityType = periodicityType;
            ComparisonType = comparisonType;
            IndicatorValueType = indicatorValueType;
            IndicatorTypeId = indicatorTypeId;
            ResponsibleId = responsibleId;
            FulfillmentRate = fulfillmentRate;
            Cumulative = cumulative;
            Status = CalculateStatus();

            AddEvent(
                new IndicatorUpdatedEvent
                {
                    IndicatorId = Id,
                    Name = Name,
                    Description = Description,
                    Code = Code,
                    Unit = Unit,
                    PeriodicityType = PeriodicityType,
                    ComparisonType = ComparisonType,
                    IndicatorValueType = IndicatorValueType,
                    IndicatorTypeId = IndicatorTypeId,
                    ResponsibleId = ResponsibleId,
                    FulfillmentRate = FulfillmentRate,
                    Cumulative = Cumulative,
                    IndicatorStatus = Status
                });
        }

        #region Measures

        public bool HasMeasures()
        {
            return Measures != null && Measures.Any();
        }

        public IndicatorMeasure GetMeasure(Guid id)
        {
            if (!HasMeasures())
            {
                return default(IndicatorMeasure);
            }

            return Measures.FirstOrDefault(m => m.Id == id);
        }

        public IndicatorMeasure GetLastMeasure()
        {
            return HasMeasures() ? Measures.OrderByDescending(m => m.Date).First() : default(IndicatorMeasure);
        }

        public void AddMeasure(DateTime date, IIndicatorValue realValue, IIndicatorValue objectiveValue, string notes)
        {
            if (Measures == null)
            {
                Measures = new List<IndicatorMeasure>();
            }

            var indicatorMeasureId = Guid.NewGuid();
            Measures.Add(new IndicatorMeasure(indicatorMeasureId, date, realValue, objectiveValue, notes));
            Status = CalculateStatus();

            AddEvent(
                new IndicatorMeasureCreatedEvent
                {
                    IndicatorMeasureId = indicatorMeasureId,
                    Date = date,
                    RealValue = realValue,
                    ObjectiveValue = objectiveValue,
                    Notes = notes,
                    IndicatorStatus = Status
                });
        }

        public void UpdateMeasure(Guid id, DateTime date, IIndicatorValue realValue, IIndicatorValue objectiveValue, string notes)
        {
            var measure = GetMeasure(id);
            if (measure == null)
            {
                throw new ItemNotFoundException("Indicator measure not found");
            }

            measure.Update(date, realValue, objectiveValue, notes);
            Status = CalculateStatus();
        }

        public void DeleteMeasure(Guid id)
        {
            var measure = GetMeasure(id);
            if (measure == null)
            {
                throw new ItemNotFoundException("Indicator measure not found");
            }

            Measures.Remove(measure);
            Status = CalculateStatus();
        }

        #endregion

        #region Status Calculation

        private IndicatorEnum.Status CalculateStatus()
        {
            if (!HasMeasures())
            {
                return IndicatorEnum.Status.Grey;
            }

            var lastMeasure = GetLastMeasure();
            if (lastMeasure.Date.AddMonths((int)PeriodicityType) < DateTime.Today)
            {
                return IndicatorEnum.Status.Grey;
            }

            switch (IndicatorValueType)
            {
                case IndicatorEnum.IndicatorValueType.Integer:
                    return CalculateStatus<int>(lastMeasure);
                case IndicatorEnum.IndicatorValueType.Decimal:
                    return CalculateStatus<decimal>(lastMeasure);
                case IndicatorEnum.IndicatorValueType.Boolean:
                    return CalculateStatus<bool>(lastMeasure);
                default:
                    throw new InvalidOperationException("Indicator measure type is not correct");
            }
        }

        private IndicatorEnum.Status CalculateStatus<T>(IndicatorMeasure lastMeasure) where T : IComparable
        {
            switch (ComparisonType)
            {
                case IndicatorEnum.ComparisonType.Equal:
                case IndicatorEnum.ComparisonType.NotEqual:
                case IndicatorEnum.ComparisonType.GreaterThan:
                case IndicatorEnum.ComparisonType.SmallerThan:
                case IndicatorEnum.ComparisonType.GreaterOrEqualThan:
                case IndicatorEnum.ComparisonType.SmallerOrEqualThan:
                    return CalculateSingleValueBasedStatus<T>(lastMeasure);
                case IndicatorEnum.ComparisonType.BetweenLimits:
                case IndicatorEnum.ComparisonType.OffLimits:
                    return CalculateSingleValueBasedStatus<T>(lastMeasure);
                default:
                    throw new InvalidOperationException("Indicator measure comparison value is not correct");
            }
        }

        private IndicatorEnum.Status CalculateSingleValueBasedStatus<T>(IndicatorMeasure lastMeasure) where T : IComparable
        {
            var realValue = lastMeasure.RealValue as SingleValue<T>;
            var objectiveValue = lastMeasure.ObjectiveValue as SingleValue<T>;
            var comparison = realValue.Value.CompareTo(objectiveValue.Value);
            if (realValue == null || objectiveValue == null)
            {
                throw new InvalidOperationException("Indicator measure values are not correct");
            }

            switch (ComparisonType)
            {
                case IndicatorEnum.ComparisonType.Equal:
                    return comparison == 0 ? IndicatorEnum.Status.Green : IndicatorEnum.Status.Red;
                case IndicatorEnum.ComparisonType.GreaterThan:
                    return comparison > 0 ? IndicatorEnum.Status.Green : IndicatorEnum.Status.Red;
                case IndicatorEnum.ComparisonType.SmallerThan:
                    return comparison < 0 ? IndicatorEnum.Status.Green : IndicatorEnum.Status.Red;
                case IndicatorEnum.ComparisonType.GreaterOrEqualThan:
                    return comparison >= 0 ? IndicatorEnum.Status.Green : IndicatorEnum.Status.Red;
                case IndicatorEnum.ComparisonType.SmallerOrEqualThan:
                    return comparison <= 0 ? IndicatorEnum.Status.Green : IndicatorEnum.Status.Red;
                default:
                    throw new InvalidOperationException("Indicator comparison type is not correct");
            }
        }

        private IndicatorEnum.Status CalculateDoubleValueBasedStatus<T>(IndicatorMeasure lastMeasure) where T : IComparable
        {
            var realValue = lastMeasure.RealValue as SingleValue<T>;
            var objectiveValue = lastMeasure.ObjectiveValue as DoubleValue<T>;
            var lowerValueComparison = realValue.Value.CompareTo(objectiveValue.LowerValue);
            var higherValueComparison = realValue.Value.CompareTo(objectiveValue.HigherValue);
            if (realValue == null || objectiveValue == null)
            {
                throw new InvalidOperationException("Indicator measure values are not correct");
            }

            switch (ComparisonType)
            {
                case IndicatorEnum.ComparisonType.BetweenLimits:
                    return lowerValueComparison >= 0 && higherValueComparison <= 0 ? IndicatorEnum.Status.Green : IndicatorEnum.Status.Red;
                case IndicatorEnum.ComparisonType.OffLimits:
                    return lowerValueComparison < 0 && higherValueComparison > 0 ? IndicatorEnum.Status.Green : IndicatorEnum.Status.Red;
                default:
                    throw new InvalidOperationException("Indicator comparison type is not correct");
            }
        }

        #endregion
    }
}
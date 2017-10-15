using BalancedScorecard.Domain.Enums;
using BalancedScorecard.Domain.Events.Indicators;
using BalancedScorecard.Kernel.Domain;
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
            Guid indicatorTypeId, 
            Guid responsibleId, 
            int? fulfillmentRate, 
            bool cumulative,
            IndicatorEnum.Status status)
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
            Status = status;
            AddEvent(new IndicatorCreatedEvent { IndicatorId = Id });
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
        public Guid IndicatorTypeId { get; private set; }

        [JsonProperty]
        public Guid ResponsibleId { get; private set; }

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
            Guid indicatorTypeId,
            Guid responsibleId,
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
        }

        public bool HasMeasures()
        {
            return Measures != null && Measures.Any();
        }

        public IndicatorMeasure GetLastMeasure()
        {
            return HasMeasures() ? Measures.OrderByDescending(m => m.Date).First() : default(IndicatorMeasure);
        }

        #region Measures

        public List<IndicatorMeasure> GetMeasures(List<IndicatorMeasure> measures)
        {
            return Measures;
        }

        public void SetMeasures(List<IndicatorMeasure> measures)
        {
            Measures = measures;
        }

        public void AddMeasure(IndicatorMeasure measure)
        {
            if (Measures == null)
            {
                Measures = new List<IndicatorMeasure>();
            }

            Measures.Add(measure);
        }

        public void UpdateMeasure(IndicatorMeasure measure)
        {
            var measureIndex = Measures.FindIndex(m => m.Id == measure.Id);
            if (measureIndex == -1)
            {
                throw new ArgumentException("Cannot find a measure with the given id");
            }

            Measures[measureIndex] = measure;
        }

        public void DeleteMeasure(IndicatorMeasure measure)
        {
            var measureIndex = Measures.FindIndex(m => m.Id == measure.Id);
            if (measureIndex == -1)
            {
                throw new ArgumentException("Cannot find a measure with the given id");
            }

            Measures.RemoveAt(measureIndex);
        }

        #endregion
    }
}
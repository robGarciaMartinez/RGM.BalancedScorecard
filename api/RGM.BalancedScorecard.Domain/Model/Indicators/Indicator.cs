﻿using RGM.BalancedScorecard.Domain.Enums;
using RGM.BalancedScorecard.Kernel.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RGM.BalancedScorecard.Domain.Model.Indicators
{
    public class Indicator : AggregateRoot
    {
        public Indicator(string name, string description, DateTime startDate, string code, string unit, IndicatorEnum.PeriodicityType periodicity, 
            IndicatorEnum.ComparisonValueType comparisonValue, IndicatorEnum.ObjectValueType objectValue, Guid indicatorTypeId, Guid responsibleId, 
            int? fulfillmentRate, bool cumulative)
        {
            Name = name;
            Description = description;
            StartDate = startDate;
            Code = code;
            Unit = unit;
            Periodicity = periodicity;
            ComparisonValue = comparisonValue;
            ObjectValue = objectValue;
            IndicatorTypeId = indicatorTypeId;
            ResponsibleId = responsibleId;
            FulfillmentRate = fulfillmentRate;
            Cumulative = cumulative;
        }

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

        public IndicatorEnum.State State { get; private set; }

        public List<IndicatorMeasure> Measures { get; private set; }

        public bool HasMeasures => Measures != null && Measures.Any();

        public IndicatorMeasure LastMeasure => HasMeasures ? Measures.OrderByDescending(m => m.Date).First() : default(IndicatorMeasure);

        public void Update(
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
        {
            Name = name;
            Description = description;
            StartDate = startDate;
            Code = code;
            Unit = unit;
            Periodicity = periodicity;
            ComparisonValue = comparisonValue;
            ObjectValue = objectValue;
            IndicatorTypeId = indicatorTypeId;
            ResponsibleId = responsibleId;
            FulfillmentRate = fulfillmentRate;
            Cumulative = cumulative;
        }

        public void SetState(IndicatorEnum.State state)
        {
            State = state;
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
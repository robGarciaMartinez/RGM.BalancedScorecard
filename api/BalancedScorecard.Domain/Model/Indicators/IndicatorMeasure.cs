using BalancedScorecard.Domain.Model.Indicators.Values;
using BalancedScorecard.Kernel.Domain;
using System;

namespace BalancedScorecard.Domain.Model.Indicators
{
    public class IndicatorMeasure : BaseEntity
    {
        public IndicatorMeasure(Guid id, DateTime date, IIndicatorValue realValue, IIndicatorValue objectiveValue, string notes)
        {
            if (id == Guid.Empty) throw new ArgumentException("Id has an invalid value");
            if (date == DateTime.MinValue || date == DateTime.MaxValue) throw new ArgumentException("Date has an invalid value");

            Id = id;
            Date = date;
            RealValue = realValue ?? throw new ArgumentException("Real value has an invalid value");
            ObjectiveValue = objectiveValue ?? throw new ArgumentException("Objective value has an invalid value");
            Notes = notes;
        }

        public DateTime Date { get; private set; }

        public IIndicatorValue RealValue { get; private set; }

        public IIndicatorValue ObjectiveValue { get; private set; }

        public string Notes { get; private set; }

        public void Update(DateTime date, IIndicatorValue realValue, IIndicatorValue objectiveValue, string notes)
        {
            if (date == DateTime.MinValue || date == DateTime.MaxValue) throw new ArgumentException("Date has an invalid value");

            Date = date;
            RealValue = realValue ?? throw new ArgumentException("Real value has an invalid value");
            ObjectiveValue = objectiveValue ?? throw new ArgumentException("Objective value has an invalid value");
            Notes = notes;
        }
    }
}
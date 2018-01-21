using BalancedScorecard.Domain.Enums;
using BalancedScorecard.Kernel.Queries;
using System;
using System.Collections.Generic;

namespace BalancedScorecard.Query.Model
{
    public class IndicatorViewModel : IViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }
       
        public string Unit { get; set; }
     
        public IndicatorEnum.PeriodicityType PeriodicityType { get; set; }
       
        public IndicatorEnum.ComparisonType ComparisonType { get; set; }
       
        public IndicatorEnum.IndicatorValueType IndicatorValueType { get; set; }

        public int? FulfillmentRate { get; set; }
    
        public bool Cumulative { get; set; }

        public IndicatorEnum.Status Status { get; set; }

        public ICollection<IndicatorMeasureViewModel> Measures { get; set; }
    }

    public class IndicatorMeasureViewModel
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public object RealValue { get; set; }

        public object ObjectiveValue { get; set; }

        public string Notes { get; set; }
    }
}

using BalancedScorecard.Domain.Enums;
using BalancedScorecard.Kernel.Queries;
using System;

namespace BalancedScorecard.Query.Model
{
    public class IndicatorViewModel : IViewModel
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }
       
        public string Unit { get; set; }
     
        public IndicatorEnum.PeriodicityType Periodicity { get; set; }
       
        public IndicatorEnum.ComparisonType ComparisonType { get; set; }
       
        public IndicatorEnum.IndicatorValueType IndicatorValueType { get; set; }

        public int? FulfillmentRate { get; set; }
    
        public bool Cumulative { get; set; }
    }
}

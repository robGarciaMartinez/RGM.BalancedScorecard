namespace RGM.BalancedScorecard.Query.Readers
{
    using System;

    using RGM.BalancedScorecard.Query.Model.Indicators;

    public interface IIndicatorsReader
    {
        IndicatorViewModel GetById(Guid id);
    }
}

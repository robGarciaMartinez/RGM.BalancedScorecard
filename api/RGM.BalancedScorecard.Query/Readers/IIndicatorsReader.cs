namespace RGM.BalancedScorecard.Query.Readers
{
    using System.Collections.Generic;

    using RGM.BalancedScorecard.Query.Model.Indicators;

    public interface IIndicatorsReader
    {
        IndicatorViewModel GetByCode(string code);

        List<IndicatorViewModel> GetIndicators(int page);
    }
}

namespace RGM.BalancedScorecard.Query.Readers
{
    using RGM.BalancedScorecard.Query.Model.Indicators;

    public interface IIndicatorsReader
    {
        IndicatorViewModel GetByCode(string code);
    }
}

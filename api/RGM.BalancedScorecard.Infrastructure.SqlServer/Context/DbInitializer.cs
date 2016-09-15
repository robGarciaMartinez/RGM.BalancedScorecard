using System.Data.Entity;

namespace RGM.BalancedScorecard.Infrastructure.SqlServer.Context
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<BalancedScorecardContext>
    {
        protected override void Seed(BalancedScorecardContext context) { }
    }
}

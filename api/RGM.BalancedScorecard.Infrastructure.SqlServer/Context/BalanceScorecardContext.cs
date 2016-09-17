using System.Data.Entity;

namespace RGM.BalancedScorecard.Infrastructure.SqlServer.Context
{
    using Microsoft.Extensions.Configuration;

    public class BalancedScorecardContext : DbContext, IDbContext
    {
        public BalancedScorecardContext(IConfiguration configuration,
            IDatabaseInitializer<BalancedScorecardContext> dbInitializer)
            : base(configuration.GetValue<string>("SqlServer:ConnectionString"))
        {
            Database.SetInitializer(dbInitializer);
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}

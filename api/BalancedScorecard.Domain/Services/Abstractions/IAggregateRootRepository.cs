using BalancedScorecard.Kernel.Domain;
using System;
using System.Threading.Tasks;

namespace BalancedScorecard.Domain.Services.Abstractions
{
    public interface IAggregateRootRepository<TAggregateRoot> where TAggregateRoot : AggregateRoot
    {
        Task<TAggregateRoot> GetAggregateRootAsync(Guid id);

        Task InsertAsync(TAggregateRoot aggregateRoot, string requestedBy);

        Task UpdateAsync(TAggregateRoot aggregateRoot, string requestedBy);
    }
}

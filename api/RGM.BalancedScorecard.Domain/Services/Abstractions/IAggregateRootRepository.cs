using RGM.BalancedScorecard.Kernel.Domain.Model;
using System;
using System.Threading.Tasks;

namespace RGM.BalancedScorecard.Domain.Services.Abstractions
{
    public interface IAggregateRootRepository<TAggregateRoot> where TAggregateRoot : AggregateRoot
    {
        Task<TAggregateRoot> GetAggregateRoot(Guid id);

        Task Insert(TAggregateRoot aggregateRoot, string requestedBy);

        Task Save(TAggregateRoot aggregateRoot, string requestedBy);
    }
}

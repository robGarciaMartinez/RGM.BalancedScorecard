using Newtonsoft.Json;
using System;

namespace BalancedScorecard.Kernel.Domain
{
    public abstract class BaseEntity
    {
        [JsonProperty]
        public Guid Id { get; protected set; }
    }
}

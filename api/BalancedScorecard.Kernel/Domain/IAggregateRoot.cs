﻿using BalancedScorecard.Kernel.Events;
using System;
using System.Collections.Generic;

namespace BalancedScorecard.Kernel.Domain
{
    public interface IAggregateRoot
    {
        Guid Id { get; }

        int Version { get; }

        ICollection<IDomainEvent> Events { get; }

        void SetVersion(int version);
    }
}

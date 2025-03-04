﻿using System.Diagnostics.CodeAnalysis;

namespace Domain.Abstractions;
[ExcludeFromCodeCoverage]
public abstract class Entity<TEntityId> : IEntity
{
    private readonly List<IDomainEvent> _domainEvents = [];
    protected Entity(TEntityId id)
    {
        Id = id;
    }
    public TEntityId Id { get; init; }
    public IReadOnlyList<IDomainEvent> GetDomainEvents()
    {
        return _domainEvents.ToList();
    }
    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
    protected void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}
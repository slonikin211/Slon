using Slon.SharedAssets.Domain.Interfaces;
using Slon.SharedAssets.Domain;

namespace Slon.SharedAssets.UnitTests.Domain;


file sealed class TestAggregate : AggregateRoot<int>
{
    public TestAggregate(int id) : base(id) { }

    public TestAggregate() : base() { }

    public void AddTestDomainEvent(IDomainEvent domainEvent)
    {
        AddDomainEvent(domainEvent);
    }
}

file sealed class TestDomainEvent : IDomainEvent
{
    public Guid Id { get; init; }
    public DateTime OccurredOnUtc { get; init; }
}


public class AggragateTests
{
    [Fact]
    public void Entity_InitializedWithId_ContainsCorrectId()
    {
        var aggregate = new TestAggregate(123);

        Assert.Equal(123, aggregate.Id);
    }

    [Fact]
    public void Entity_InitializedWithoutId_ContainsDefaultId()
    {
        var aggregate = new TestAggregate();

        Assert.Equal(default(int), aggregate.Id);
    }

    [Fact]
    public void Entity_CanAddDomainEvent()
    {
        var aggregate = new TestAggregate();
        var domainEvent = new TestDomainEvent();

        aggregate.AddTestDomainEvent(domainEvent);

        var events = aggregate.DomainEvents.ToList();
        Assert.Single(events);
        Assert.Equal(domainEvent, events[0]);
    }

    [Fact]
    public void Entity_CanRetrieveDomainEvents()
    {
        var aggregate = new TestAggregate();
        var domainEvent1 = new TestDomainEvent();
        var domainEvent2 = new TestDomainEvent();

        aggregate.AddTestDomainEvent(domainEvent1);
        aggregate.AddTestDomainEvent(domainEvent2);

        var events = aggregate.DomainEvents;
        Assert.Equal(2, events.Count);
    }

    [Fact]
    public void Entity_CanClearDomainEvents()
    {
        var aggregate = new TestAggregate();
        var domainEvent = new TestDomainEvent();

        aggregate.AddTestDomainEvent(domainEvent);
        Assert.Single(aggregate.DomainEvents);

        aggregate.ClearDomainEvents();
        Assert.Empty(aggregate.DomainEvents);
    }
}
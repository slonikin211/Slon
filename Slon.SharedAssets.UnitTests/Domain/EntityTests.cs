using Slon.SharedAssets.Domain.Interfaces;
using Slon.SharedAssets.Domain;

namespace Slon.SharedAssets.UnitTests.Domain;


file sealed class TestEntity : Entity<int>
{
    public TestEntity(int id) : base(id) { }

    public TestEntity() : base() { }

    public void AddTestDomainEvent(IDomainEvent domainEvent)
    {
        AddDomainEvent(domainEvent);
    }
}

file sealed class TestDomainEvent : IDomainEvent { }


public class EntityTests
{
    [Fact]
    public void Entity_InitializedWithId_ContainsCorrectId()
    {
        var entity = new TestEntity(123);

        Assert.Equal(123, entity.Id);
    }

    [Fact]
    public void Entity_InitializedWithoutId_ContainsDefaultId()
    {
        var entity = new TestEntity();

        Assert.Equal(default(int), entity.Id);
    }

    [Fact]
    public void Entity_CanAddDomainEvent()
    {
        var entity = new TestEntity();
        var domainEvent = new TestDomainEvent();

        entity.AddTestDomainEvent(domainEvent);

        var events = entity.GetDomainEvents();
        Assert.Single(events);
        Assert.Equal(domainEvent, events[0]);
    }

    [Fact]
    public void Entity_CanRetrieveDomainEvents()
    {
        var entity = new TestEntity();
        var domainEvent1 = new TestDomainEvent();
        var domainEvent2 = new TestDomainEvent();

        entity.AddTestDomainEvent(domainEvent1);
        entity.AddTestDomainEvent(domainEvent2);

        var events = entity.GetDomainEvents();
        Assert.Equal(2, events.Count);
    }

    [Fact]
    public void Entity_CanClearDomainEvents()
    {
        var entity = new TestEntity();
        var domainEvent = new TestDomainEvent();

        entity.AddTestDomainEvent(domainEvent);
        Assert.Single(entity.GetDomainEvents());

        entity.ClearDomainEvents();
        Assert.Empty(entity.GetDomainEvents());
    }
}
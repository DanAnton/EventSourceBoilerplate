using Beersender.Domain;
using Beersender.Domain.BeerPackages.Commands;
using Beersender.Domain.BeerPackages.Events;
using FluentAssertions;

namespace Beersender.Tests;

public abstract class BeersenderTest
{
    private Event[] _events = null!;
    private readonly List<Event> _newEvents = new();

    protected void Given(params Event[] events)
    {
        _events = events;
    }

    protected void When<TCommand>(TCommand command) where TCommand: Command
    {
        new CommandRouter(_ => _events, @event => _newEvents.Add(@event)).HandleCommand(command);
    }

    protected void Then(params Event[] expectedEvents)
    {
        _newEvents.Should().BeEquivalentTo(expectedEvents);
    }
}
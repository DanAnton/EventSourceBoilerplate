using Beersender.Domain;
using Beersender.Domain.Infrastructure;
using FluentAssertions;

namespace Beersender.tests;

public abstract class BeersenderTest
{
    private readonly List<IEvent> _events = new();

    private readonly List<IEvent> _newEvents = new();

    protected void Given(params IEvent[] events)
    {
        _events.Clear();
        _events.AddRange(events);
    }

    protected void When(ICommand command)
    {
        var router = new CommandRouter(_ => _events, @event => _newEvents.Add(@event.Event));
        router.Handle_command(command);
    }

    protected void Then(params IEvent[] expectedEvents)
    {
        _newEvents.ToArray().Should().Equal(expectedEvents);
    }
}
using Beersender.Domain.Commands;
using Beersender.Domain.Commands.Routers;
using Beersender.Domain.Events;
using FluentAssertions;

namespace Beersender.Tests;

public abstract class Beersender_test
{
    private readonly List<IEvent> _events = new();
    protected void Given(params IEvent[] events)
    {
        _events.Clear();
        _events.AddRange(events);
    }

    protected void When(ICommand command)
    {
        var router = new Beer_package_router(_ => _events, @event => _new_events.Add(@event));
        router.Handle_command(command);
    }

    private readonly List<IEvent> _new_events = new();

    protected void Then(params IEvent[] expected_events)
    {
        _new_events.ToArray().Should().Equal(expected_events);
    }
}
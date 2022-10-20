using Beersender.Domain;
using Beersender.Domain.Infrastructure;
using FluentAssertions;

namespace Beersender.Tests;

public abstract class Beersender_test
{
    private readonly List<Event> _events = new();
    protected void Given(params Event[] events)
    {
        _events.Clear();
        _events.AddRange(events);
    }

    protected void When(Command command)
    {
        var router = new Command_router(_ => _events, @event => _new_events.Add(@event));
        router.Handle_command(command);
    }

    private readonly List<Event> _new_events = new();

    protected void Then(params Event[] expected_events)
    {
        _new_events.ToArray().Should().Equal(expected_events);
    }
}
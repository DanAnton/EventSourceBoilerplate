using Beersender.Domain;
using Beersender.Domain.Beer_packages.Commands;
using Beersender.Domain.Beer_packages.Events;
using FluentAssertions;

namespace Beersender.tests;

public abstract class Beersender_test
{
    public Beersender_test()
    {
            
    }

    private Package_event[] _events;
    protected void Given(params Package_event[] events)
    {
        _events = events;
    }

    protected void Given(IEnumerable<Package_event> events)
    {
        _events = events.ToArray();
    }

    protected void When(Package_command command)
    {
        var router = new Command_router(_ => _events, @event => _new_events.Add(@event));
        router.Handle_command(command);
    }

    private List<object> _new_events = new();

    protected void Then(params Package_event[] expected_events)
    {
        _new_events.ToArray().Should().BeEquivalentTo(expected_events);
    }
}
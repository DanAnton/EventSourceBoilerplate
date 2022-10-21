using Beersender.Domain;
using FluentAssertions;

namespace Beersender.tests;

public abstract class Beersender_test
{
    public Beersender_test()
    {
            
    }

    private IEvent[] _events;
    protected void Given(params IEvent[] events)
    {
        _events = events;
    }

    protected void When(ICommand command)
    {
        var router = new Command_router(_ => _events, @event => _new_events.Add(@event));
        router.Handle_command(command);
    }

    private List<IEvent> _new_events = new();

    protected void Then(params IEvent[] expected_events)
    {
        _new_events.ToArray().Should().BeEquivalentTo(expected_events, options => options.RespectingRuntimeTypes());
    }
}
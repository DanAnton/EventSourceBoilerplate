using Beersender.Domain;
using FluentAssertions;

namespace Beersender.tests;

public abstract class Beersender_test
{
	private List<IEvent> _events = new();
	private readonly List<IEvent> _new_events = new();

	protected void Given(params IEvent[] events)
	{
		_events = events.ToList();
	}

	protected void When(ICommand command)
	{
		var router = new Command_router(_ => _events, @event => _new_events.Add(@event));
		router.Handle_command(command);
	}

	protected void When(params ICommand[] commands)
	{
		var router = new Command_router(_ => _events, @event =>
		{
			_new_events.Add(@event);
			_events.Add(@event);
		});

		foreach (var command in commands)
		{
			router.Handle_command(command);
		}
	}

	protected void Then(params IEvent[] expected_events)
	{
		_new_events.ToArray().Should().BeEquivalentTo(expected_events, options => options.RespectingRuntimeTypes());
	}
}
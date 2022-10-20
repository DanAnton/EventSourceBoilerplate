using Beersender.Domain.Beer_packages;
using Beersender.Domain.Infrastructure;

namespace Beersender.Domain.Command_handlers;

internal class Command_handler<TCommand, TAggregate>
    where TCommand : Command
    where TAggregate : Aggregate, new()
{
    private readonly Func<Guid, IEnumerable<object>> _event_stream;
    private readonly Action<object> _publish_event;

    protected Command_handler(Func<Guid, IEnumerable<object>> event_stream,
        Action<object> publish_event)
    {
        _event_stream = event_stream;
        _publish_event = publish_event;
    }

    public void Handle(TCommand command)
    {
        var previous_events = _event_stream(command.Aggregate_id);

        var aggregate = new TAggregate();

        foreach (var previous_event in previous_events)
        {
            aggregate.Apply(previous_event);
        }

        var resulting_events = aggregate.Handle(command);

        foreach (var resulting_event in resulting_events)
        {
            _publish_event(resulting_event);
        }
    }
}
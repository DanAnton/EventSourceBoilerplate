using Beersender.Domain.Aggregates;
using Beersender.Domain.Events;

namespace Beersender.Domain.Commands;

internal class Beer_package_handler<TCommand, TAggregate>
    where TCommand : ICommand
    where TAggregate : Aggregate, new()
{
    private readonly Func<Guid, IEnumerable<IEvent?>> _event_stream;
    private readonly Action<IEvent> _publish_event;

    internal Beer_package_handler(Func<Guid, IEnumerable<IEvent?>> event_stream,
        Action<IEvent> publish_event)
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
            if (previous_event is not null)
            {
                aggregate.Apply(previous_event);
            }
        }

        var resulting_events = aggregate.Handle(command);

        foreach (var resulting_event in resulting_events)
        {
            _publish_event(resulting_event);
        }
    }
}
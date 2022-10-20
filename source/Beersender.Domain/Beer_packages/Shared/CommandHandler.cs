using Beersender.Domain.Beer_packages.Commands;
using Beersender.Domain.Beer_packages.Interfaces;

namespace Beersender.Domain.Beer_packages.Shared;

public abstract class CommandHandler<T,TA> : IHandler<T> where T : ICommand where TA: Aggregate, new()
{
    public Func<Guid, IEnumerable<object>> event_stream { get; }
    public Action<object> publish_event { get; }

    protected CommandHandler(Func<Guid, IEnumerable<object>> Event_stream, Action<object> Publish_event)
    {
        event_stream = Event_stream;
        publish_event = Publish_event;
    }

    public void Handle(T command)
    {
        var previous_events = event_stream(command.AggregateId);

        var aggregate = new TA();

        foreach (var previous_event in previous_events)
            aggregate.Apply(previous_event);

        var resulting_events = aggregate.Handle(command);

        foreach (var resulting_event in resulting_events)
            publish_event(resulting_event);
    }
}
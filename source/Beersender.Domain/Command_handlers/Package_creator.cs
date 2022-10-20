using Beersender.Domain.Beer_packages;
using Beersender.Domain.Beer_packages.Commands;

namespace Beersender.Domain.Command_handlers;

internal class Package_creator
{
    private readonly Func<Guid, IEnumerable<IEvent>> event_stream;
    private readonly Action<IEvent> publish_event;

    public Package_creator(
        Func<Guid, IEnumerable<IEvent>> Event_stream,
        Action<IEvent> Publish_event)
    {
        event_stream = Event_stream;
        publish_event = Publish_event;
    }

    public void Handle(Create_package command)
    {
        var previous_events = event_stream(command.Package_id);

        var aggregate = new Beer_package();

        foreach (var previous_event in previous_events)
        {
            aggregate.Apply(previous_event);
        }

        var resulting_events = aggregate.Handle(command);

        foreach (var resulting_event in resulting_events)
        {
            publish_event(resulting_event);
        }
    }
}
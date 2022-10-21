using Beersender.Domain.Aggregates;
using Beersender.Domain.Events;

namespace Beersender.Domain.Commands;

public class Beer_package_router<TCommand>
    where TCommand : ICommand
{
    private readonly Func<Guid, IEnumerable<IEvent?>> event_stream;
    private readonly Action<IEvent> publish_event;

    public Beer_package_router(
        Func<Guid, IEnumerable<IEvent?>> Event_stream,
        Action<IEvent> Publish_event)
    {
        event_stream = Event_stream;
        publish_event = Publish_event;
    }

    public void Handle_command(TCommand command)
    {
        var beer_package_handler = new Beer_package_handler<TCommand, Beer_package>(event_stream, publish_event);
        beer_package_handler.Handle(command);
    }
}
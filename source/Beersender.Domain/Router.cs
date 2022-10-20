using Beersender.Domain.BeerPackages.Commands;
using Beersender.Domain.BeerPackages.Events;

namespace Beersender.Domain;

public class CommandRouter
{
    private readonly Func<Guid, IEnumerable<Event>> _eventStream;
    private readonly Action<Event> _publishEvent;

    public CommandRouter(Func<Guid, IEnumerable<Event>> eventStream, Action<Event> publishEvent)
    {
        _eventStream = eventStream;
        _publishEvent = publishEvent;
    }

    public void HandleCommand<TCommand>(TCommand command) where TCommand : Command
    {
        new Handler<TCommand>(_eventStream, _publishEvent).Handle(command);
    }
}
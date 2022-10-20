using Beersender.Domain.BeerPackages;
using Beersender.Domain.BeerPackages.Commands;
using Beersender.Domain.BeerPackages.Events;

namespace Beersender.Domain.CommandHandlers;

public class Handler<TCommand> where TCommand : Command
{
    private readonly Func<Guid, IEnumerable<Event>> _eventStream;
    private readonly Action<Event> _publishEvent;

    public Handler(Func<Guid, IEnumerable<Event>> eventStream, Action<Event> publishEvent)
    {
        _eventStream = eventStream;
        _publishEvent = publishEvent;
    }

    public void Handle(TCommand command)
    {
        var previousEvents = _eventStream(command.PackageId);
        var aggregate = new BeerPackage();
        foreach (var previousEvent in previousEvents)
        {
            aggregate.Apply(previousEvent);
        }

        var resultingEvents = aggregate.Handle(command);
        foreach (var resultingEvent in resultingEvents)
        {
            _publishEvent(resultingEvent);
        }
    }
}
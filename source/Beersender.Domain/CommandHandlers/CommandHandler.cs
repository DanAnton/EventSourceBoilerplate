using Beersender.Domain.BeerPackages;
using Beersender.Domain.Infrastructure;

namespace Beersender.Domain.CommandHandlers;

internal class CommandHandler<TCommand, TAggregate>
    where TCommand : ICommand
    where TAggregate : Aggregate, new()
{
    private readonly Func<Guid, IEnumerable<IEvent>> _eventStream;
    private readonly Action<EventMessage> _publishEvent;

    protected CommandHandler(Func<Guid, IEnumerable<IEvent>> eventStream,
        Action<EventMessage> publishEvent)
    {
        _eventStream = eventStream;
        _publishEvent = publishEvent;
    }

    public void Handle(TCommand command)
    {
        var previousEvents = _eventStream(command.AggregateId);

        var aggregate = new TAggregate();

        foreach (var previousEvent in previousEvents) aggregate.Apply(previousEvent);

        var resultingEvents = aggregate.Handle(command);

        foreach (var resultingEvent in resultingEvents)
            _publishEvent(new EventMessage(command.AggregateId, resultingEvent));
    }
}
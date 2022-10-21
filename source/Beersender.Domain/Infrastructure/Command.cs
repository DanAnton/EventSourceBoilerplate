namespace Beersender.Domain.Infrastructure;

public interface ICommand
{
    public Guid AggregateId { get; }
}
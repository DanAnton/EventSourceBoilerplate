namespace Beersender.Domain.Commands;

public interface ICommand
{
    public Guid Aggregate_id { get; }
}
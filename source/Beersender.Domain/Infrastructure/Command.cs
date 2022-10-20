namespace Beersender.Domain.Infrastructure;

public interface Command
{
    public Guid Aggregate_id { get; }
}
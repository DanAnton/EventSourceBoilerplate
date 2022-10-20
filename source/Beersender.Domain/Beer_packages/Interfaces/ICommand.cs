namespace Beersender.Domain.Beer_packages.Interfaces;

public interface ICommand
{
    public Guid AggregateId { get; set; }
}
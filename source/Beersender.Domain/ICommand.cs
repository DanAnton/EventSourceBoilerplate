namespace Beersender.Domain;

public interface ICommand
{
    public Guid Package_id { get; }
}

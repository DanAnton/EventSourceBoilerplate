namespace Beersender.Domain.Beer_packages.Interfaces;

public interface IHandler<in T> where T : ICommand
{
    public void Handle(T command);
}
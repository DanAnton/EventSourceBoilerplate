namespace Beersender.Domain.Beer_packages.Commands
{
    public abstract record BaseCommand
    {
        public abstract IEnumerable<object> Execute();
    }
}

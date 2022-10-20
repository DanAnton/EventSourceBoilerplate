using Beersender.Domain.Beer_packages.Events;

namespace Beersender.Domain.Beer_packages.Commands;

public record Create_package(Guid Package_id): BaseCommand
{
    public override IEnumerable<object> Execute()
    {
        yield return new Package_created(Package_id);
    }
}

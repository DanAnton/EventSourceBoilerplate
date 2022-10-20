namespace Beersender.Domain.Beer_packages.Commands;

public sealed record Send_package(Guid Package_id): Package_command(Package_id);

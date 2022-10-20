namespace Beersender.Domain.Beer_packages.Commands;

public record struct Create_package(Guid Package_id) : ICommand;

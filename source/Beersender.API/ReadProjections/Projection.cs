using Beersender.API.ReadStore;
using Beersender.Domain.BeerPackages;
using Beersender.Domain.Infrastructure;

namespace Beersender.API.ReadProjections;

public interface IProjection
{
    void Dispatch(IEvent @event);
}

public class PackageStatusUpdater : IProjection
{
    private static readonly Predicate<IEvent> ShouldProcess =
        e => e is PackageCreated or ShippingLabelAdded or PackageSent;

    private readonly IServiceProvider _services;


    public PackageStatusUpdater(IServiceProvider services)
    {
        _services = services;
    }

    public void Dispatch(IEvent @event)
    {
        if (!ShouldProcess(@event))
            return;

        using var readDb = _services.CreateScope().ServiceProvider.GetService<ReadContext>();

        var packageStatus = @event switch
        {
            PackageCreated created => new PackageStatus { PackageId = created.PackageId, Status = "Created" },
            ShippingLabelAdded labelAdded => new PackageStatus
            {
                PackageId = labelAdded.PackageId, Status = "Label added"
            },
            PackageSent sent => new PackageStatus { PackageId = sent.PackageId, Status = "Sent" },
            _ => null
        };

        var record = readDb.PackageStatuses.Find(packageStatus.PackageId);

        if (record == null)
            readDb.PackageStatuses.Add(packageStatus);
        else
            record.Status = packageStatus.Status;

        readDb.SaveChanges();
    }
}
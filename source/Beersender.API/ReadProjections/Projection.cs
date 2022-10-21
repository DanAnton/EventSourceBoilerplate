using Beersender.API.Read_store;
using Beersender.Domain.Beer_packages.Events;
using Beersender.Domain.Infrastructure;

namespace Beersender.API.ReadProjections;

    public interface Projection
    {
        void Dispatch(Event @event);
    }

    public class PackageStatusUpdater : Projection
    {
        private readonly IServiceProvider _services;


        public PackageStatusUpdater(IServiceProvider services)
        {
            _services = services;
        }

        private static Predicate<Event> ShouldProcess = (
            e => e is Package_created ||
                 e is Shipping_label_added ||
                 e is Package_sent);

        public void Dispatch(Event @event)
        {
            if (!ShouldProcess(@event))
                return;

            using var readDb = _services.CreateScope().ServiceProvider.GetService<ReadContext>();
            
            PackageStatus packageStatus = null;

            switch (@event)
            {
                case Package_created created:
                    packageStatus = new PackageStatus
                    {
                        PackageId = created.Package_id,
                        Status = "Created"
                    };
                    break;
                case Shipping_label_added label_added:
                    packageStatus = new PackageStatus
                    {
                        PackageId = label_added.Package_id,
                        Status = "Label added"
                    };
                    break;
                case Package_sent sent:
                    packageStatus = new PackageStatus
                    {
                        PackageId = sent.Package_id,
                        Status = "Sent"
                    };
                    break;
                //TODO Add other event type
        }

            var record = readDb.PackageStatuses.Find(packageStatus.PackageId);

            if (record == null)
            {
                readDb.PackageStatuses.Add(packageStatus);
            }
            else
            {
                record.Status = packageStatus.Status;
            }

            readDb.SaveChanges();
        }
    }

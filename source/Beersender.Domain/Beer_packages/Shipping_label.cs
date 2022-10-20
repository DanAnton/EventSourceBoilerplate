using Beersender.Domain.Beer_packages.Interfaces;

namespace Beersender.Domain.Beer_packages;

public enum Shipping_provider
{
    UPS,
    DHL,
    PostNL,
    FedEx
}
public record Shipping_label(Shipping_provider Shipping_provider, string Tracking_code): IRecord
{
    public bool Is_valid()
    {
        // TODO: implement proper checking on the label format
        return Tracking_code.Length > 6;
    }
}


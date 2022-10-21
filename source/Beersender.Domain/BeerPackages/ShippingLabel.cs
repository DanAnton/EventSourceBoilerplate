namespace Beersender.Domain.BeerPackages;

public enum ShippingProvider
{
    UPS,
    DHL,
    PostNL,
    FedEx
}

public record ShippingLabel(ShippingProvider ShippingProvider, string TrackingCode)
{
    public bool Is_valid()
    {
        // TODO: implement proper checking on the label format
        return TrackingCode.Length > 6;
    }
}
namespace Beersender.Domain.BeerPackages;

public record ShippingLabel(ShippingProvider ShippingProvider, string TrackingCode)
{
    public bool IsValid()
    {
        // ToDo: implement proper check on the label format
        return TrackingCode.Length > 6;
    }
}
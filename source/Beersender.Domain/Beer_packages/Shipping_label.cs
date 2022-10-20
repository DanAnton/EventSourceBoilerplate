namespace Beersender.Domain.Beer_packages;

public enum Shipping_provider
{
    UPS,
    DHL,
    PostNL,
    FedEx
}
public readonly record struct Shipping_label(
    Shipping_provider Shipping_provider,
    string Tracking_code)
{
    public bool Is_valid()
    {
        // TODO: implement proper checking on the label format
        return Tracking_code.Length > 6;
    }
}


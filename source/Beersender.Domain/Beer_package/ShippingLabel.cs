namespace Beersender.Domain.Beer_package;

public enum Shipping_provider
{
    UPS,
    DHL,
    PostNL,
    FedEx
}

public record Shipping_label(Shipping_provider Shipping_Provider,
    string Tracking_code)
{
    public bool Is_valid()
    {
        // TODO: implemente proper checking on the label format
        return Tracking_code.Length > 6;
    }
}

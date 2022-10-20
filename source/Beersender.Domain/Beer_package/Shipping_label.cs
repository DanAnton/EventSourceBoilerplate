namespace Beersender.Domain.Beer_package;

public enum Shipping_provider {
    UPS,
    DHL,
    FeedEx
}
public record Shipping_label(Shipping_provider Shipping_provider, string Tracking_code)
{
    public bool Is_valid() {
        return Tracking_code.Length > 6;
    }
}

using Beersender.Domain.BeerPackages;

namespace Beersender.tests;

public partial class WhenAddShippingLabel
{
    protected AddShippingLabel Add_valid_shipping_label_to_package1()
    {
        return new AddShippingLabel(Package1Id, ValidShippingLabel);
    }
}
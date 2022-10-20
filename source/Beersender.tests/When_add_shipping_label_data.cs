using Beersender.Domain.Beer_packages;
using Beersender.Domain.Beer_packages.Commands;

namespace Beersender.tests;

public partial class When_add_shipping_label
{
    protected Add_shipping_label Add_valid_shipping_label_to_package1()
    {
        return new Add_shipping_label(package1_id, valid_shipping_label);
    }
}


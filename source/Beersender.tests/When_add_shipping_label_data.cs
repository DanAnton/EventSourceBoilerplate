using Beersender.Domain.Commands;

namespace Beersender.Tests;

public partial class When_add_shipping_label
{
    protected Add_shipping_label Add_valid_shipping_label_to_package1()
    {
        return new Add_shipping_label(package1_id, valid_shipping_label);
    }
}


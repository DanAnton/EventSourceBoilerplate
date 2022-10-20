using Beersender.Domain.Beer_packages.Events;

namespace Beersender.Domain.Beer_packages.Commands
{
    public record Add_shipping_label(Guid Label_id) : BaseCommand
    {
        public bool IsValid()
        {
            return Label_id != Guid.Empty;
        }

        public override IEnumerable<object> Execute()
        {
            if (IsValid())
            {
                yield return new Shipping_label_added(Label_id);
            }
            else
            {
                yield return new Shipping_label_failed_to_add(Label_id);
            }
        }
    }

}

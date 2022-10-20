namespace Beersender.Domain.Beer_packages.Commands
{
    public record struct Add_shipping_label(Guid Label_id)
    {
        public bool IsValid()
        {
            return Label_id != Guid.Empty;
        }
    }

}

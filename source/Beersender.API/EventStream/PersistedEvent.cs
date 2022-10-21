using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Beersender.Domain.Infrastructure;

namespace Beersender.API.EventStream;

public class PersistedEvent
{
    private IEvent? _event;
    public int Id { get; set; }
    public Guid AggregateId { get; set; }

    [MaxLength(256)] public string? EventType { get; set; }

    public string? EventBody { get; set; }
    public DateTime Timestamp { get; set; }

    [NotMapped]
    [JsonIgnore]
    public IEvent? Event
    {
        get
        {
            if (_event == null && EventType != null)
            {
                var type = Type.GetType(EventType);
                _event = (IEvent)JsonSerializer.Deserialize(EventBody, type)!;
            }

            return _event;
        }
        set
        {
            if (!(_event?.Equals(value) ?? false))
            {
                _event = value;

                EventType = _event?.GetType().AssemblyQualifiedName;
                EventBody = JsonSerializer.Serialize(_event, _event?.GetType()!);
            }
        }
    }
}
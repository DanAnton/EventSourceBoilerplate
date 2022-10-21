using System.Text.Json;
using System.Text.Json.Serialization;
using Beersender.Domain.Infrastructure;

namespace Beersender.API.JsonConverters;

public class CommandConverter : JsonConverter<ICommand>
{
    private static readonly Dictionary<string, Type> TypeLookup = new();

    static CommandConverter()
    {
        var commandTypes = typeof(ICommand)
            .Assembly
            .GetTypes()
            .Where(type => !type.IsAbstract && typeof(ICommand).IsAssignableFrom(type));

        foreach (var commandType in commandTypes) TypeLookup[commandType.Name] = commandType;
    }

    public override bool CanConvert(Type type)
    {
        return typeof(ICommand).IsAssignableFrom(type);
    }

    public override ICommand Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject) throw new JsonException();

        if (!reader.Read()
            || reader.TokenType != JsonTokenType.PropertyName
            || reader.GetString()!.ToLower() != "$type")
            throw new JsonException();

        if (!reader.Read() || reader.TokenType != JsonTokenType.String) throw new JsonException();

        var typeDiscriminator = reader.GetString()!;
        var commandType = TypeLookup[typeDiscriminator];


        if (!reader.Read() || reader.GetString()!.ToLower() != "command") throw new JsonException();
        if (!reader.Read() || reader.TokenType != JsonTokenType.StartObject) throw new JsonException();

        var command = (ICommand)JsonSerializer.Deserialize(ref reader, commandType)!;

        if (!reader.Read() || reader.TokenType != JsonTokenType.EndObject) throw new JsonException();

        return command;
    }

    public override void Write(
        Utf8JsonWriter writer,
        ICommand value,
        JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        writer.WriteString("$type", value.GetType().Name);
        writer.WritePropertyName("command");
        JsonSerializer.Serialize(writer, value, value.GetType());

        writer.WriteEndObject();
    }
}
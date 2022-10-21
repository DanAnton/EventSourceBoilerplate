using System.Text.Json;
using System.Text.Json.Serialization;
using Beersender.Domain.Infrastructure;

namespace Beersender.API.JsonConverters
{
    // TODO: make this work
    public class CommandConverter : JsonConverter<Command>
    {
        private static Dictionary<string, Type> TypeLookup = new();
        static CommandConverter()
        {
            var command_types = typeof(Command)
                .Assembly
                .GetTypes()
                .Where(type => !type.IsAbstract && typeof(Command).IsAssignableFrom(type));

            foreach (var command_type in command_types)
            {
                TypeLookup[command_type.Name] = command_type;
            }
        }

        public override bool CanConvert(Type type)
        {
            return typeof(Command).IsAssignableFrom(type);
        }

        public override Command Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            if (!reader.Read()
                    || reader.TokenType != JsonTokenType.PropertyName
                    || reader.GetString() != "$type")
            {
                throw new JsonException();
            }

            if (!reader.Read() || reader.TokenType != JsonTokenType.String)
            {
                throw new JsonException();
            }

            var type_name = reader.GetString();
            var type = TypeLookup[type_name];

            Command command = (Command)JsonSerializer.Deserialize(ref reader, type);

            if (!reader.Read() || reader.TokenType != JsonTokenType.EndObject)
            {
                throw new JsonException();
            }

            return command;
        }

        public override void Write(
            Utf8JsonWriter writer,
            Command value,
            JsonSerializerOptions options)
        {
            var commandType = value.GetType();

            JsonSerializer.Serialize(writer, commandType);
        }
    }
}

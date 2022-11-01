using System.Globalization;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Common.Other.Converters;

public class DateOnlyJsonConverter : JsonConverter<DateOnly>
{ // The default json converter currently does not support DateOnly and TimeOnly, this will change in c sharp 11 / dotnet 7.
    private const string Format = "yyyy-MM-dd";

    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateOnly.ParseExact(reader.GetString(), Format, CultureInfo.InvariantCulture);
    }

    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(Format, CultureInfo.InvariantCulture));
    }
}
using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

// https://github.com/Artsdatabanken/Fremmedartsbase2023/blob/main/Prod.Domain/Helpers/JsonHelpers.cs

namespace Assessments.Mapping.AlienSpecies.Helpers
{
    public class JsonHelpers
    {
        /// <summary>
        /// because of bad handling of int in some javascript code - need to convert string empty to int = 0 and back as string
        /// </summary>
        public class CrazyIntJsonConverter : JsonConverter<int>
        {
            public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType == JsonTokenType.Null)
                {
                    return 0;
                }
                if (reader.TokenType == JsonTokenType.Number)
                {
                    return reader.GetInt32();
                }

                var value = reader.GetString();
                return string.IsNullOrWhiteSpace(value) ? 0 : int.Parse(value);
            }

            public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(value == 0 ? "" : value.ToString());
            }
        }
        public class CrazyStringJsonConverter : JsonConverter<string>
        {
            public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType == JsonTokenType.Null)
                {
                    return string.Empty;
                }
                if (reader.TokenType == JsonTokenType.Number)
                {
                    var int32 = reader.GetInt32();
                    if (int32 == 0)
                    {
                        return string.Empty;
                    }
                    return int32.ToString();
                }
                
                return reader.GetString();
            }

            public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
            {
                // For performance, lift up the writer implementation.
                if (value == null)
                {
                    writer.WriteNullValue();
                }
                else
                {
                    writer.WriteStringValue(value.AsSpan());
                }
            }
        }


        public class BoolJsonConverter : JsonConverter<bool>
        {
            public override bool Read(
                ref Utf8JsonReader reader,
                Type typeToConvert,
                JsonSerializerOptions options)
            {
                if (reader.TokenType == JsonTokenType.False)
                {
                    return false;
                }

                if (reader.TokenType == JsonTokenType.True)
                {
                    return true;
                }

                if (reader.TokenType == JsonTokenType.Null)
                {
                    return false;
                }

                var value = reader.GetString();
                return value != null && (value.ToLowerInvariant() == "true");
            }

            public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
            {
                writer.WriteBooleanValue(value);
            }
        }

        public class BoolNullableJsonConverter : JsonConverter<bool?>
        {
            public override bool? Read(
                ref Utf8JsonReader reader,
                Type typeToConvert,
                JsonSerializerOptions options)
            {
                if (reader.TokenType == JsonTokenType.False)
                {
                    return false;
                }

                if (reader.TokenType == JsonTokenType.True)
                {
                    return true;
                }

                if (reader.TokenType == JsonTokenType.Null)
                {
                    return null;
                }

                var value = reader.GetString();
                return value != null && (value.ToLowerInvariant() == "true");
            }

            public override void Write(Utf8JsonWriter writer, bool? value, JsonSerializerOptions options)
            {
                if (value.HasValue)
                {
                    writer.WriteBooleanValue(value.Value);
                }
                else
                {
                    writer.WriteNullValue();

                }
            }
        }


        public class DoubleJsonConverter : System.Text.Json.Serialization.JsonConverter<double?>
        {
            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(double) || objectType == typeof(double?);
            }

            public override double? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                switch (reader.TokenType)
                {
                    case JsonTokenType.Number:
                        return reader.GetDouble();
                    case JsonTokenType.String:
                        {
                            double temp;
                            var attempted = reader.GetString().Replace(",", ".");
                            if (double.TryParse(
                                attempted,
                                NumberStyles.Number,
                                CultureInfo.InvariantCulture,
                                out temp)
                            )
                            {
                                return temp;
                            }

                            break;
                        }
                }

                return null;
            }

            public override void Write(Utf8JsonWriter writer, double? value, JsonSerializerOptions options)
            {
                if (value.HasValue)
                {
                    writer.WriteNumberValue(value.Value);
                }
                else
                {
                    writer.WriteNullValue();
                }

            }
        }
    }
}

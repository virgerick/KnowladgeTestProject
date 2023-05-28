using System.Text.Json;
namespace Api.Extensions;

public static class JsonExtensions
{
    private static JsonSerializerOptions jsonOption = new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true
    };

    public static string JsonSerialize(this object obj) => JsonSerializer.Serialize(obj, jsonOption);

    public static T JsonDeserialize<T>(this string json, JsonSerializerOptions? options = null)
    {
        options ??= jsonOption;
        return JsonSerializer.Deserialize<T>(json, options)!;
    }
}
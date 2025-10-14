using System.Text.Json.Serialization;

namespace Finances_Uno.Models.DataModels;
public partial class Breed
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("temperament")]
    public string? Temperament { get; set; }

    [JsonPropertyName("origin")]
    public string? Origin { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("wikipedia_url")]
    public Uri? WikipediaUrl { get; set; }
}

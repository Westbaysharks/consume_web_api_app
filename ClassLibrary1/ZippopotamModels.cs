using System.Text.Json.Serialization;

namespace ConsumeAPI
{
    // Huvudklassen för svaret från Zippopotam
    public class CityInfo
    {
        [JsonPropertyName("post code")]
        public string? PostCode { get; set; }

        [JsonPropertyName("country")]
        public string? Country { get; set; }

        // "places" i JSON är en lista (array), så vi använder List<Place>
        [JsonPropertyName("places")]
        public List<Place>? Places { get; set; }
    }

    // En hjälpklass eftersom "places" innehåller detaljerad info
    public class Place
    {
        [JsonPropertyName("place name")]
        public string? PlaceName { get; set; }

        [JsonPropertyName("longitude")]
        public string? Longitude { get; set; }

        [JsonPropertyName("latitude")]
        public string? Latitude { get; set; }
    }
}
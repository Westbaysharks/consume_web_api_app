using System.Text.Json.Serialization;

namespace ConsumeAPI // Byt eventuellt ut detta mot vad ditt projekt heter
{
    // Denna klass är ritningen för hur datan från GitHub ser ut
    public class Repository
    {
        // Vi använder [JsonPropertyName] för att koppla JSON-fältet "name" 
        // till vår C#-egenskap "Name".
        // Detta gör att vi kan ha stor bokstav i koden trots att JSON är liten.
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        // I JSON heter den "html_url", men här döper vi om den till GitHubUrl
        // för att det ska vara tydligare vad det är.
        [JsonPropertyName("html_url")]
        public string? GitHubUrl { get; set; }

        [JsonPropertyName("homepage")]
        public string? Homepage { get; set; }

        [JsonPropertyName("watchers")]
        public int Watchers { get; set; }

        [JsonPropertyName("pushed_at")]
        public DateTime LastPush { get; set; }
    }
}
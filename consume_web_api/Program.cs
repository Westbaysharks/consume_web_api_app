using ConsumeAPI;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

// Här skapar vi en HttpClient för att kunna göra anrop mot nätet.
using HttpClient client = new HttpClient();

// GitHub kräver en "User-Agent" header.
client.DefaultRequestHeaders.Add("User-Agent", "MyConsoleApp");

Console.WriteLine("Fetching data from GitHub...");
Console.WriteLine("-----------------------------");

try
{
    // --- GitHub ---
    string url = "https://api.github.com/orgs/dotnet/repos";

    // Vi hämtar datan som en ström
    var responseStream = await client.GetStreamAsync(url);

    // Deserialisera JSON till en lista av våra Repository-objekt
    var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(responseStream);

    if (repositories != null)
    {
        foreach (var repo in repositories)
        {
            Console.WriteLine($"Name: {repo.Name}");
            Console.WriteLine($"Homepage: {repo.Homepage}");
            Console.WriteLine($"GitHub: {repo.GitHubUrl}");
            Console.WriteLine($"Description: {repo.Description}");
            Console.WriteLine($"Watchers: {repo.Watchers}");
            Console.WriteLine($"Last push: {repo.LastPush}");
            Console.WriteLine();
        }
    }

    // --- Zippopotam ---
    Console.WriteLine("--- Zippopotam ---");

    string zipUrl = "https://api.zippopotam.us/us/nj/montvale";

    var zipStream = await client.GetStreamAsync(zipUrl);
    var cityInfo = await JsonSerializer.DeserializeAsync<CityInfo>(zipStream);

    if (cityInfo != null && cityInfo.Places != null && cityInfo.Places.Count > 0)
    {
        var place = cityInfo.Places[0];
        Console.WriteLine($"City: {place.PlaceName}, {cityInfo.Country}");
        Console.WriteLine($"Zip Code: {place.PostCode}");
        Console.WriteLine($"Latitude: {place.Latitude}");
        Console.WriteLine($"Longitude: {place.Longitude}");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Ett fel inträffade: {ex.Message}");
}

Console.ReadLine();

namespace ConsumeAPI
{
    internal class CityInfo
    {
        [JsonPropertyName("country")]
        public string? Country { get; set; }

        [JsonPropertyName("places")]
        public List<Place>? Places { get; set; }
    }

    internal class Place
    {
        [JsonPropertyName("place name")]
        public string? PlaceName { get; set; }

        [JsonPropertyName("post code")]
        public string? PostCode { get; set; }

        [JsonPropertyName("longitude")]
        public string? Longitude { get; set; }

        [JsonPropertyName("latitude")]
        public string? Latitude { get; set; }
    }

    internal class Repository
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("homepage")]
        public string? Homepage { get; set; }

        [JsonPropertyName("html_url")]
        public string? GitHubUrl { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("watchers")]
        public int Watchers { get; set; }

        [JsonPropertyName("pushed_at")]
        public DateTime LastPush { get; set; }
    }
}
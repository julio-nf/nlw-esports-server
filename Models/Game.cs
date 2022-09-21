using System.Text.Json.Serialization;

namespace server.Models;

public class Game
{
    
    public Guid Id { get; set; }

    public string Title { get; set; }

    public string BannerUrl { get; set; }

    [JsonIgnore]
    public List<Ad> Ads { get; set; }
}
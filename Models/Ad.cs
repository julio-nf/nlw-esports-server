using System.Text.Json.Serialization;

namespace server.Models;

public class Ad
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int YearsPlaying { get; set; }

    public string Discord { get; set; } = string.Empty;

    public List<int> WeekDays { get; set; }

    public int HourStart { get; set; }

    public int HourEnd { get; set; }

    public bool UseVoiceChannel { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public Guid GameId { get; set; }
    
    [JsonIgnore]
    public Game? Game { get; set; }
}
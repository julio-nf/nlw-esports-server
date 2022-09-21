namespace server.Dtos;

public record AdDto
{
    public string Name { get; init; }

    public int YearsPlaying { get; init; }

    public string Discord { get; init; }

    public List<int> WeekDays { get; init; }

    public string HourStart { get; init; }

    public string HourEnd { get; init; }

    public bool UseVoiceChannel { get; init; }
}
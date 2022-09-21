using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Data;

public class DataContext : DbContext
{
    private readonly JsonSerializerOptions _defaultJsonOptions = new();

    public DbSet<Game> Games { get; set; }

    public DbSet<Ad> Ads { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ad>()
            .Property(x => x.CreatedAt)
            .HasDefaultValueSql("datetime('now')");

        modelBuilder.Entity<Ad>()
            .Property(a => a.WeekDays)
            .HasConversion(
                a => JsonSerializer.Serialize(a, (JsonSerializerOptions)null),
                a => JsonSerializer.Deserialize<List<int>>(a, (JsonSerializerOptions)null));

        var leagueOfLegends = new Game
        {
            Id = Guid.NewGuid(),
            Title = "League of Legends",
            BannerUrl = "https://static-cdn.jtvnw.net/ttv-boxart/21779-188x250.jpg"
        };

        modelBuilder.Entity<Game>()
            .HasData(new Game[]
            {
                leagueOfLegends,
                new()
                {
                    Id = Guid.NewGuid(),
                    Title = "Counter-Strike",
                    BannerUrl = "https://static-cdn.jtvnw.net/ttv-boxart/32399_IGDB-188x250.jpg"
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Title = "Valorant",
                    BannerUrl = "https://static-cdn.jtvnw.net/ttv-boxart/516575-188x250.jpg"
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Title = "World of Warcraft",
                    BannerUrl = "https://static-cdn.jtvnw.net/ttv-boxart/18122-285x380.jpg"
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Title = "Apex Legends",
                    BannerUrl = "https://static-cdn.jtvnw.net/ttv-boxart/511224-285x380.jpg"
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Title = "Fortnite",
                    BannerUrl = "https://static-cdn.jtvnw.net/ttv-boxart/33214-285x380.jpg"
                }
            });

        modelBuilder.Entity<Ad>()
            .HasData(new Ad
            {
                Id = Guid.NewGuid(),
                Name = "bbJoinha",
                YearsPlaying = 12,
                Discord = "Xablau",
                WeekDays = new List<int> { 0,1,2,3,4,5,6 },
                HourStart = 1080,
                HourEnd = 1260,
                UseVoiceChannel = true,
                GameId = leagueOfLegends.Id
            });
    }
}
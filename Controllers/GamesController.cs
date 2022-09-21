using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Dtos;
using server.Models;

namespace server.Controllers;

[Route("[controller]")]
[ApiController]
public class GamesController : ControllerBase
{
    private readonly DataContext _context;

    public GamesController(DataContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<ActionResult<string>> Get()
    {
        var games = await _context.Games
            .Select(g => new
            {
                Game = g,
                AdsCount = g.Ads.Count
            })
            .ToListAsync();

        return Ok(games);
    }

    [HttpGet]
    [Route("{id:guid}/ads")]
    public async Task<ActionResult<List<string>>> GetAds(Guid id)
    {
        var ads = await _context.Ads
            .Where(a => a.GameId == id)
            .OrderByDescending(a => a.CreatedAt)
            .Select(a => new
            {
                a.Id,
                a.Name,
                a.WeekDays,
                a.UseVoiceChannel,
                a.YearsPlaying,
                HourStart = ConvertMinutesToHourString(a.HourStart),
                HourEnd = ConvertMinutesToHourString(a.HourEnd)
            })
            .ToListAsync();

        return Ok(ads);
    }
    
    [HttpPost]
    [Route("{gameId:guid}/ads")]
    public async Task<ActionResult<Ad>> PostAds(Guid gameId, [FromBody] AdDto adDto)
    {
        Ad ad = new()
        {
            Id = default,
            Name = adDto.Name,
            YearsPlaying = adDto.YearsPlaying,
            Discord = adDto.Discord,
            WeekDays = adDto.WeekDays,
            HourStart = ConvertHourStringToMinutes(adDto.HourStart),
            HourEnd = ConvertHourStringToMinutes(adDto.HourEnd),
            UseVoiceChannel = adDto.UseVoiceChannel,
            GameId = gameId,
        };

        var createdAd = _context.Ads.Add(ad);
        await _context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(PostAds), createdAd.Entity);
    }

    private static int ConvertHourStringToMinutes(string timeString)
    {
        var time = TimeSpan.Parse(timeString, CultureInfo.InvariantCulture);

        return (int)time.TotalMinutes;
    }

    private static string ConvertMinutesToHourString(int minutes)
    {
        var time = TimeSpan.FromMinutes(minutes);

        return time.ToString(@"hh\:mm");
    }
}
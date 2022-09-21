using Microsoft.AspNetCore.Mvc;
using server.Data;

namespace server.Controllers;

[Route("[controller]")]
[ApiController]
public class AdsController : ControllerBase
{
    private readonly DataContext _context;

    public AdsController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("{id:guid}/discord")]
    public async Task<ActionResult<string>> GetDiscord(Guid id)
    {
        var ad = await _context.Ads.FindAsync(id);
        
        return ad is not null ? 
            Ok(new { ad.Discord }) :
            NotFound();
    } 
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace ActiveArenaApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FighterController : ControllerBase
{
    private readonly ILogger<FighterController> _logger;

    public FighterController(ILogger<FighterController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public async Task<ActionResult<Fighter>> CreateFighter()
    {
        _logger.LogInformation("Creating fighter");
        var accessToken = Request.Headers[HeaderNames.Authorization].First();
        var user = SupabaseUtils.IsAuthenticatedAsync(accessToken).Result;
        if (user == null) return Unauthorized();

        var fighter = Fighter.GenerateFighter();
        var fighterRow = new FighterRow(fighter, user.Id);

        await SupabaseUtils.Supabase.From<FighterRow>().Insert(fighterRow);
        _logger.LogInformation("Created fighter for user {userId}", user.Id);

        return fighter; 
    }
}

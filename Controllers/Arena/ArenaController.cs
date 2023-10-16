using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace ActiveArenaApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ArenaController : ControllerBase
{
    private readonly ILogger<ArenaController> _logger;
    private readonly IArenaSource _arenaSource;

    public ArenaController(ILogger<ArenaController> logger, IArenaSource arenaSource)
    {
        _logger = logger;
        _arenaSource = arenaSource;
    }

    [HttpPut]
    public async Task<ActionResult<Arena>> JoinOpenArena([FromBody] string fighterId)
    {
        _logger.LogInformation($"{fighterId} is joining an arena");
        var accessToken = Request.Headers[HeaderNames.Authorization].First();
        var user = SupabaseUtils.IsAuthenticatedAsync(accessToken).Result;
        if (user == null) return Unauthorized();

        var fighterResponse = await SupabaseUtils.Supabase.From<FighterRow>().Match(new Dictionary<string, string> {{"owner", user.Id}, {"id", fighterId}}).Get();
        var fighter = JsonSerializer.Deserialize<List<Fighter>>(fighterResponse.Content).First();
        
        bool addedFighter;
        Arena arena;
        
        do
        {
            arena = _arenaSource.GetOpenArena();
            addedFighter = arena.AddFighter(fighter);
        } while (!addedFighter);

        _logger.LogInformation($"Added {fighterId} to {arena.Id}");

        return Ok(arena);
    }

}
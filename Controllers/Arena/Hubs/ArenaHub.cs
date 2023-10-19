using Microsoft.AspNetCore.SignalR;

public class ArenaHub : Hub
{
    private readonly ILogger<ArenaHub> _logger;
    public ArenaHub(ILogger<ArenaHub> logger)
    {
        _logger = logger;
    }

    public async Task JoinArena(string arenaId)
    {
        _logger.LogInformation("Joining arena {arenaId}", arenaId);
        await Groups.AddToGroupAsync(Context.ConnectionId, arenaId);

        var arena = ArenaStore.Arenas.FirstOrDefault(s => s.Id == Guid.Parse(arenaId));
    }

    public async Task UpdateArena(Arena arena)
    {
        await Clients.Group(arena.Id.ToString()).SendAsync("UpdateArena", arena);
    }

    public async Task UpdateFightersInArena(Arena arena)
    {
        await Clients.Group(arena.Id.ToString()).SendAsync("UpdateArenaFighters", arena.Fighters);
    }
}
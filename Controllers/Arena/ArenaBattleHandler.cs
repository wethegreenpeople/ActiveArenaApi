using Microsoft.AspNetCore.SignalR;

public static class ArenaBattleHandler
{
    private static IArenaSource _arenaSource;
    private static IHubContext<ArenaHub> _hubContext;

    public static void Initialize(IArenaSource arenaSource, IHubContext<ArenaHub> hubContext)
    {
        _arenaSource = arenaSource;
        _hubContext = hubContext;
    }
    
    public static async Task ArenaUpdate(Guid arenaId)
    {
        var arena = _arenaSource.GetArena(arenaId);

        while (arena.Started)
        {
            foreach (var fighter in arena.Fighters)
            {
                fighter.Move();
            }

            await _hubContext.Clients.Group(arenaId.ToString()).SendAsync("UpdateArena", arena);
            await Task.Delay(30);
        }
    }
}
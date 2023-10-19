using Microsoft.AspNetCore.SignalR;

public static class ArenaBattleHandler
{
    private static IArenaSource _arenaSource;
    private static IHubContext<ArenaHub> _hubContext;

    public static void Initialize(IArenaSource arenaSource, IHubContext<ArenaHub> hubContext)
    {
        _arenaSource = arenaSource;
        _hubContext = hubContext;
        ArenaManagementCron();
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

    public static async Task ArenaManagementCron()
    {
        while (true)
        {
            foreach (var arena in ArenaStore.Arenas)
            {
                if (!arena.Started && arena.Fighters.Count() >= 1 && arena.Fighters.Count() < 5)
                {
                    arena.AddFighter(Fighter.GenerateFighter());
                    var arenaUpdate = _hubContext.Clients.Group(arena.Id.ToString()).SendAsync("UpdateArena", arena);
                    var fightersUpdate = _hubContext.Clients.Group(arena.Id.ToString()).SendAsync("UpdateArenaFighters", arena);
                    await Task.WhenAll(arenaUpdate, fightersUpdate);
                    
                    // If a bot is the last fighter to be added, we need to trigger the arena update
                    if (arena.Fighters.Count() == 4)
                    {
                        arena.Started = true;
                        _ = ArenaBattleHandler.ArenaUpdate(arena.Id);
                    }
                        
                }
            }
            await Task.Delay(5000);
        }
    }
}
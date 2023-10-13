public class InMemoryArenaSource : IArenaSource
{
    public Arena GetOpenArena()
    {
        var arena = ArenaStore.Arenas.FirstOrDefault(s => s.Fighters.Count() < 4, null);
        if (arena == null)
        {
            var newArena = new Arena(Guid.NewGuid());
            ArenaStore.Arenas.Add(newArena);
            return newArena;
        }
        
        return arena;
    }

    public Arena GetArena(Guid arenaId) => ArenaStore.Arenas.FirstOrDefault(s => s.Id == arenaId);
}

public static class ArenaStore
{
    public static List<Arena> Arenas = new();
}
public interface IArenaSource
{
    Arena GetOpenArena();
    Arena GetArena(Guid arenaId);
}
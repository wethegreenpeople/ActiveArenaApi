using System.Text.Json.Serialization;

public class Arena {
    public Guid Id { get; }

    public List<FighterLocation> Fighters { get; private set; } = new();

    [JsonIgnore]
    public bool Started { get; set; }

    public Arena(Guid id)
    {
        this.Id = id;
    }

    public bool AddFighter(Guid fighterId)
    {
        if (Fighters.Count() >= 4) return false;
        if (Fighters.Any(s => s.FighterId == fighterId)) return true;

        var rand = new Random();
        var XLoc = rand.Next(0, 100);
        var YLoc = rand.Next(0, 100);

        this.Fighters.Add(new FighterLocation(fighterId, XLoc, YLoc));

        return true;
    }
}
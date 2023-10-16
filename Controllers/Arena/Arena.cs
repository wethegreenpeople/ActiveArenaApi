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

    public bool AddFighter(Fighter fighter)
    {
        if (Fighters.Count() >= 4) return false;
        if (Fighters.Any(s => s.FighterId == fighter.Id)) return true;

        var rand = new Random();
        var XLoc = rand.Next(10, 90);
        var YLoc = rand.Next(10, 90);

        this.Fighters.Add(new FighterLocation(fighter.Id, fighter.Speed, XLoc, YLoc));

        return true;
    }
}
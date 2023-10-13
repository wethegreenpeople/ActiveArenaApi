public class FighterLocation 
{
    public Guid FighterId { get; }
    public double XLoc { get; }
    public double YLoc { get; }

    public FighterLocation(Guid fighter, double x, double y)
    {
        this.FighterId = fighter;
        this.XLoc = x;
        this.YLoc = y;
    }
}
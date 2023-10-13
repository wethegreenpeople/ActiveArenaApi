using System.Text.Json.Serialization;

public class FighterLocation 
{
    public Guid FighterId { get; }

    public double XLoc { get; private set; }
    public double YLoc { get; private set; }
    public short XDirection { get; private set; } = 0;
    public short YDirection { get; private set; } = 1;

    public FighterLocation(Guid fighter, double x, double y)
    {
        this.FighterId = fighter;
        this.XLoc = x;
        this.YLoc = y;
    }

    public void Move()
    {
        if (this.XLoc <= 0 || this.XLoc >= 100) this.XDirection *= -1;
        if (this.YLoc <= 0 || this.YLoc >= 100) this.YDirection *= -1;

        this.XLoc += this.XDirection;
        this.YLoc += this.YDirection;
    }
}
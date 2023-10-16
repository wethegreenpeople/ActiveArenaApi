using System.Text.Json.Serialization;

public class FighterLocation 
{
    public Guid FighterId { get; }

    [JsonIgnore]
    public double FighterSpeed { get; }

    public double XLoc { get; private set; }
    public double YLoc { get; private set; }
    public short XDirection { get; private set; } = 0;
    public short YDirection { get; private set; } = 1;

    public FighterLocation(Guid fighter, double fighterSpeed, double x, double y)
    {
        this.FighterId = fighter;
        this.FighterSpeed = fighterSpeed;
        this.XLoc = x;
        this.YLoc = y;
    }

    public void Move()
    {
        short chooseRandomDirection(short currentDirection)
        {
            if (currentDirection == 0) return (short)RandomGenerationUtils.Random.Next(-1, 2);
            
            var shouldChangeDirection = RandomGenerationUtils.HappensWithChance(20);
            return shouldChangeDirection ? (short)(currentDirection * -1) : currentDirection;
        }
        
        if (this.XLoc <= 2 || this.XLoc >= 98)
        {
            this.XDirection *= -1;
            this.YDirection = chooseRandomDirection(this.YDirection);
        }
        if (this.YLoc <= 2 || this.YLoc >= 98)
        {
            this.YDirection *= -1;
            this.XDirection = chooseRandomDirection(this.XDirection);
        }

        this.XLoc += this.XDirection * (this.FighterSpeed / 100);
        this.YLoc += this.YDirection * (this.FighterSpeed / 100);
    }
}
public class Fighter
{
    public Guid Id {get;}
    public int Health {get;}
    public string Name {get;}

    public Fighter(Guid id, int health, string name)
    {
        Id = id;
        Health = health;
        Name = name;
    }

    public static Fighter GenerateFighter()
    {
        var rand = new Random();

        var health = rand.Next(50, 150);
        var name = NameUtils.GetFullName();

        return new Fighter(Guid.NewGuid(), health, name);
    }
}
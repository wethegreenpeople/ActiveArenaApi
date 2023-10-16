using System.Text.Json.Serialization;

public class Fighter
{
    [JsonPropertyName("id")]
    public Guid Id {get;}

    [JsonPropertyName("health")]
    public int Health {get;}

    [JsonPropertyName("speed")]
    public int Speed {get;}

    [JsonPropertyName("name")]
    public string Name {get;}

    public Fighter(Guid id, int health, int speed, string name)
    {
        Id = id;
        Health = health;
        Speed = speed;
        Name = name;
    }

    public static Fighter GenerateFighter()
    {
        var rand = new Random();

        var health = rand.Next(50, 150);
        var speed = rand.Next(10, 60);
        var name = NameUtils.GetFullName();

        return new Fighter(Guid.NewGuid(), health, speed, name);
    }
}
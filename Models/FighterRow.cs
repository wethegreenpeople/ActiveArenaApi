using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Postgrest.Attributes;
using Postgrest.Models;

[Table("fighters")]
public class FighterRow : BaseModel
{
    [PrimaryKey("id")]
    public Guid Id {get;}

    [Column("health")]
    public int Health {get;}

    [Column("name")]
    public string Name {get;}

    [Column("owner")]
    public Guid Owner {get;}

    public FighterRow()
    {
        
    }

    public FighterRow(Fighter fighter, string ownerId)
    {
        Id = fighter.Id;
        Health = fighter.Health;
        Name = fighter.Name;
        Owner = Guid.Parse(ownerId);
    }
}
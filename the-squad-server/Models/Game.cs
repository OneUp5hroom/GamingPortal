using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace the_squad_server.Models;

public class Game
{
    [Key]
    public int GameId { get; set; }
    public string Name { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public bool Active { get; set; }
    public bool Generic { get; set; }

    [ForeignKey("CreatorId")]
    [InverseProperty("Games")]
    public virtual Creator? CreatorAssignment { get; set; }

    public Game()
    {

    }

    public Game(string name, string imageUrl, bool active)
    {
        Name = name;
        ImageUrl = imageUrl;
        Active = active;
    }
}
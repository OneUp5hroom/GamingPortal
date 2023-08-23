namespace the_squad_server.Models;

public class StreamingService
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string LogoUrl { get; set; } = null!;
    public bool Active { get; set; }
}
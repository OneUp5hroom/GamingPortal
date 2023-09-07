
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace the_squad_server.Models;

public class Server
{
    public int Id { get; set; }
    public Guid ServerGUID { get; set; }
    public string Name { get; set; }
    public ICollection<ServerRole> ServerRoleNames { get; set; }
    public string? ServerPicture { get; set; } = null!;
    public string? ServerDNSAddress { get; set; } = null!;
    public ServerStatus? Status { get; set; }
    public string? ServerConnectionPassword { get; set; } = null!;
    public int? ServerConnectionPort { get; set; } = null;
    public string? ServerInstructions { get; set; } = null!;

    public Server()
    {
        ServerGUID = Guid.NewGuid();
        ServerRoleNames = new List<ServerRole>();
    }
    public Server(string name)
    {
        ServerGUID = Guid.NewGuid();
        Name = name;
        Status = ServerStatus.Unknown;
        ServerRoleNames = new List<ServerRole>();
    }
}

public class ServerRole
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    [ForeignKey("ServerId")]
    [InverseProperty("ServerRoleNames")]
    public virtual Server? ServerAssignment { get; set; }

    public ServerRole()
    {
    }
    public ServerRole(string name)
    {
        Name = name;
    }
}

public enum ServerStatus
{
    Online,
    Offline,
    Deallocated,
    Unknown
}
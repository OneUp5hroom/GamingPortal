
using System.ComponentModel.DataAnnotations;

namespace the_squad_server.Models;

public class Server
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ServerStatus? Status { get; set; }
    public ICollection<ServerRole> ServerRoleNames { get; set; }
    public string? ServerPicture { get; set; } = null!;

    public Server ()
    {
        Id = Guid.NewGuid();
        ServerRoleNames = new List<ServerRole>();
    }
    public Server(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        Status = ServerStatus.Unknown;
        ServerRoleNames = new List<ServerRole>();
    }
}

public class ServerRole
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string MappedIdentityRole { get; set; }

    public ServerRole()
    {
        Id = Guid.NewGuid();
    }
    public ServerRole(string name, string identityRoleGUID)
    {
        Id = Guid.NewGuid();
        Name = name;
        MappedIdentityRole = identityRoleGUID;
    }
}

public enum ServerStatus
{
    Online,
    Offline,
    Deallocated,
    Unknown
}
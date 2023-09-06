using Microsoft.EntityFrameworkCore;
using the_squad_server.Models;

#nullable enable

namespace the_squad_server.Data;
public class ServerManager<Tcrt> : IDisposable where Tcrt : class
{
    private ApplicationDbContext? _context;
    public ServerManager()
    {}
    public ServerManager(ApplicationDbContext context)
    {
        _context = context;
    }
    public List<Server> ListServers()
    {
        return _context.Servers.Include(s => s.ServerRoleNames).ToList();
    }
    public Server GetServer(Server _Server)
    {
        var Server = _context.Servers.Include(s => s.ServerRoleNames).FirstOrDefault(g => g.Name == _Server.Name);
        return Server;
    }
    public List<ServerRole> ListServerRoles()
    {
        return _context.ServerRoles.ToList();
    }
    public List<Server> ListServersbyRole(List<string> roleList)
    {
        List<Server> ServerList = new List<Server>();
        var servers = _context.Servers.ToList();
        foreach (var server in servers) {
            foreach (var role in roleList)
            {
                var match = server.ServerRoleNames.FirstOrDefault(r => r.Name == role);
                if (match != null)
                {
                    ServerList.Add(server);
                }
            }
        }
        return ServerList;
    }

    public async Task AddRoleToServerAsync(Server _server, ServerRole _serverRole)
    {
        var serv = await _context.Servers.FirstOrDefaultAsync(s => s.Id == _server.Id);
        if (serv != null)
        {
            _serverRole.ServerAssignment = serv;
            await _context.AddAsync(_serverRole);
            await _context.SaveChangesAsync();
        }
    }
    public async Task SetAsync(Server _server)
    {
        if (isNewServer(_server))
        {
            await _context.AddAsync(_server);
            await _context.SaveChangesAsync();
        }
        else if ( ServersMatch(_server) )
        {
            _context.Servers.Update(_server);
            await _context.SaveChangesAsync(); 
        }
        else
        {
            await UpdateAsync(_server);
        }
    }
    public async Task UpdateAsync(Server _server)
    {
        var ServerFromDB = _context.Servers.Include(s => s.ServerRoleNames).FirstOrDefault(g => g.Id == _server.Id);
        if (ServerFromDB != null)
        {
            ServerFromDB.Name = _server.Name;
            ServerFromDB.ServerRoleNames = _server.ServerRoleNames.Count > 0 ? _server.ServerRoleNames : new List<ServerRole>();
            ServerFromDB.ServerPicture = _server.ServerPicture;
            ServerFromDB.ServerDNSAddress = _server.ServerDNSAddress;
            ServerFromDB.ServerConnectionPassword = _server.ServerConnectionPassword;
            ServerFromDB.ServerInstructions = _server.ServerInstructions;
            await _context.SaveChangesAsync();
        }
    }
    public bool isNewServer(Server _server)
    {
        var ServerFromDB = _context.Servers.FirstOrDefault(g => g.Id == _server.Id);
        if (ServerFromDB == null)
        {
            return true;
        }
        return false;
    }

    public bool ServersMatch(Server _server)
    {
        var ServerFromDB = _context.Servers.FirstOrDefault(g => g.Id == _server.Id);
        if (ServerFromDB != null && ServerFromDB == _server)
        {
            return true;
        }
        return false;
    }
    //public bool ValidateCreatorServers(Server Server)
    //{
    //    var ServerFromDB = _context.Servers.FirstOrDefault(g => g.CreatorId )
    //}
    public async Task DeleteAsync(Server _Server)
    {
        _context.Remove(_Server);
        await _context.SaveChangesAsync();
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (disposing) 
        {
            _context = null;
        }
    }
}
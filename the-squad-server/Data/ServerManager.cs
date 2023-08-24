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
        return _context.Servers.ToList();
    }
    public Server GetServer(Server _Server)
    {
        var Server = _context.Servers.FirstOrDefault(g => g.Name == _Server.Name);
        return Server;
    }
    public async Task SetAsync(Server Server)
    {
        if (isNewServer(Server))
        {
            await _context.AddAsync(Server);
            await _context.SaveChangesAsync();
        }
        else
        {
            await UpdateAsync(Server);
        }
    }
    public async Task UpdateAsync(Server Server)
    {
        var ServerFromDB = _context.Servers.FirstOrDefault(g => g.Name == Server.Name);
        if (ServerFromDB != null)
        {
            ServerFromDB.Name = Server.Name;
            //ServerFromDB.ImageUrl = Server.ImageUrl;
            await _context.SaveChangesAsync();
        }
    }
    public bool isNewServer(Server Server)
    {
        var ServerFromDB = _context.Servers.FirstOrDefault(g => g.Name == Server.Name);
        if (ServerFromDB == null)
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
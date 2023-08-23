using the_squad_server.Models;

#nullable enable

namespace the_squad_server.Data;
public class StreamingServiceManager<Tcrt> : IDisposable where Tcrt : class
{
    private ApplicationDbContext? _context;
    public StreamingServiceManager()
    {}
    public StreamingServiceManager(ApplicationDbContext context)
    {
        _context = context;
    }
    public List<StreamingService> ListStreamingServices(bool creatorStreamingServices = false)
    {
        List<StreamingService> StreamingServicesList = new List<StreamingService>();
        if (creatorStreamingServices)
        {
            try{
                StreamingServicesList = _context.StreamingServices.ToList();
            } catch {}
        }
        else
        {
            try {
                StreamingServicesList = _context.AvailableStreamingServices.ToList();
            } catch {}
        }
        return StreamingServicesList;
    }
    public StreamingService GetStreamingService(StreamingService _StreamingService)
    {
        var StreamingService = _context.StreamingServices.FirstOrDefault(g => g.Name == _StreamingService.Name);
        return StreamingService;
    }
    public async Task SetAsync(StreamingService StreamingService)
    {
        if (isNewStreamingService(StreamingService))
        {
            await _context.AddAsync(StreamingService);
            await _context.SaveChangesAsync();
        }
        else
        {
            await UpdateAsync(StreamingService);
        }
    }
    public async Task UpdateAsync(StreamingService StreamingService)
    {
        var StreamingServiceFromDB = _context.StreamingServices.FirstOrDefault(g => g.Name == StreamingService.Name);
        if (StreamingServiceFromDB != null)
        {
            StreamingServiceFromDB.Name = StreamingService.Name;
            //StreamingServiceFromDB.ImageUrl = StreamingService.ImageUrl;
            await _context.SaveChangesAsync();
        }
    }
    public bool isNewStreamingService(StreamingService StreamingService)
    {
        var StreamingServiceFromDB = _context.StreamingServices.FirstOrDefault(g => g.Name == StreamingService.Name);
        if (StreamingServiceFromDB == null)
        {
            return true;
        }
        return false;
    }
    //public bool ValidateCreatorStreamingServices(StreamingService StreamingService)
    //{
    //    var StreamingServiceFromDB = _context.StreamingServices.FirstOrDefault(g => g.CreatorId )
    //}
    public async Task DeleteAsync(StreamingService _StreamingService)
    {
        _context.Remove(_StreamingService);
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
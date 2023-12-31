using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using the_squad_server.Models;

#nullable enable

namespace the_squad_server.Data;
public class CreatorManager<Tcrt> : IDisposable where Tcrt : class
{
    private ApplicationDbContext? _context;
    public CreatorManager()
    {}
    public CreatorManager(ApplicationDbContext context)
    {
        _context = context;
    }
    public Creator GetCreator(IdentityUser _user)
    {
        var creator = _context.Creators.Include(c => c.Games).Include(c => c.StreamingServices).FirstOrDefault(c => c.UserId == _user.Id);
        return creator;
    }
    public Creator GetDefaultCreator()
    {
        var creator = _context.Creators.FirstOrDefault(c => c.UserId == "Default");
        if (creator == null)
        {
            creator = new Creator(true);
        }
        return creator;

    }
    public List<Creator> GetCreatorsAll()
    {
        List<Creator> allCreators = _context.Creators.Include(c => c.Games).Include(c => c.StreamingServices).Where(c => c.UserId != "Default").ToList();
        return allCreators;
    }
    public async Task SetCreator(Creator _creator)
    {
        await _context.AddAsync(_creator);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateCreator(Creator _creator)
    {
        var creatorFromDB = _context.Creators.FirstOrDefault(c => c.CreatorId == _creator.CreatorId);
        if (creatorFromDB != null)
        {
                creatorFromDB.ProfilePictureUrl = _creator.ProfilePictureUrl;
                creatorFromDB.ProfileDescription = _creator.ProfileDescription;
                creatorFromDB.Games = _creator.Games.Count > 0 ? _creator.Games : new List<Game>();
                creatorFromDB.StreamingServices = _creator.StreamingServices.Count > 0 ? _creator.StreamingServices : new List<StreamingService>();
                creatorFromDB.Active = _creator.Active;
                await _context.SaveChangesAsync();
        }
    }
    public async Task DeleteCreator(Creator _creator)
    {
        _context.Remove(_creator);
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
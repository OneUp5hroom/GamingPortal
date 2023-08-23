using the_squad_server.Models;

#nullable enable

namespace the_squad_server.Data;
public class GameManager<Tcrt> : IDisposable where Tcrt : class
{
    private ApplicationDbContext? _context;
    public GameManager()
    {}
    public GameManager(ApplicationDbContext context)
    {
        _context = context;
    }
    public List<Game> ListGames(bool creatorGames = false)
    {
        List<Game> GamesList = new List<Game>();
        if (creatorGames)
        {
            try{
                GamesList = _context.Games.ToList();
            } catch {}
        }
        else
        {

            try {
                GamesList = _context.AvailableGames.ToList();
            } catch {}
        }
        return GamesList;
    }
    public Game GetGame(Game _Game)
    {
        var Game = _context.Games.FirstOrDefault(g => g.Name == _Game.Name);
        return Game;
    }
    public async Task SetAsync(Game game)
    {
        if (isNewGame(game))
        {
            await _context.AddAsync(game);
            await _context.SaveChangesAsync();
        }
        else
        {
            await UpdateAsync(game);
        }
    }
    public async Task UpdateAsync(Game game)
    {
        var GameFromDB = _context.Games.FirstOrDefault(g => g.Name == game.Name);
        if (GameFromDB != null)
        {
            GameFromDB.Name = game.Name;
            GameFromDB.ImageUrl = game.ImageUrl;
            await _context.SaveChangesAsync();
        }
    }
    public bool isNewGame(Game game)
    {
        var GameFromDB = _context.Games.FirstOrDefault(g => g.Name == game.Name);
        if (GameFromDB == null)
        {
            return true;
        }
        return false;
    }
    //public bool ValidateCreatorGames(Game game)
    //{
    //    var GameFromDB = _context.Games.FirstOrDefault(g => g.CreatorId )
    //}
    public async Task DeleteAsync(Game _Game)
    {
        _context.Remove(_Game);
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
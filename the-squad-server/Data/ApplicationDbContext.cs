using Microsoft.EntityFrameworkCore;
using the_squad_server.Models;

namespace the_squad_server.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Creator> Creators { get; set; } = null!;
    public DbSet<Game> Games { get; set; } = null!;
    public DbSet<Server> Servers { get; set; } = null!;
    public DbSet<ServerRole> ServerRoles { get; set; } = null!;
    public IQueryable<Game> AvailableGames => Games.Where(g => g.Generic == true);
    public DbSet<StreamingService> StreamingServices { get; set; } = null!;
    public IQueryable<StreamingService> AvailableStreamingServices => StreamingServices.Where(g => g.Generic == true);
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
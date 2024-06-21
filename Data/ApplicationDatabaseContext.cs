using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class ApplicationDatabaseContext : DbContext{
    public ApplicationDatabaseContext(DbContextOptions <ApplicationDatabaseContext> dbContextOptions) :base (dbContextOptions){
        
    }
    public DbSet<Match> Matches { get; set; }
    public DbSet<MatchParticipation> MatchParticipation { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Referee> Referees { get; set; }
    public DbSet<Substitution> Substitutions { get; set; }
    public DbSet<Team> Teams { get; set; }

}
using Data;

namespace Services;

public class TeamServices
{
    public readonly ApplicationDatabaseContext _dbContext;
    public TeamServices (ApplicationDatabaseContext dbContext){
        _dbContext = dbContext;
    }
    public async Task Post(Team team){
        await _dbContext.Teams.AddAsync(team);
        await _dbContext.SaveChangesAsync();
    }
    public List<Team> Get(){
        return _dbContext.Teams.ToList();
    }

    public async Task Update (Team team)
    {
        var existingTeam = await _dbContext.Teams.FindAsync(team.TeamId);
        if (existingTeam != null)
        {
            existingTeam.TeamName = team.TeamName;
            existingTeam.MainStadium = team.MainStadium;
            existingTeam.City = team.City;

            _dbContext.Teams.Update(existingTeam);
            await _dbContext.SaveChangesAsync();
        }
    } 

    public async Task Delete (int TeamId)
    {
        var existingTeam = await _dbContext.Teams.FindAsync(TeamId);
        if (existingTeam != null)
        {
            _dbContext.Teams.Remove(existingTeam);
            await _dbContext.SaveChangesAsync();
        }
    } 
}
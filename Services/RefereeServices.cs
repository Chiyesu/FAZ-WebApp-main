using Data;

namespace Services;

public class RefereeServices
{
    public readonly ApplicationDatabaseContext _dbContext;
    public RefereeServices (ApplicationDatabaseContext dbContext){
        _dbContext = dbContext;
    }
    public async Task Post(Referee referee){
        await _dbContext.Referees.AddAsync(referee);
        await _dbContext.SaveChangesAsync();
    }
    public List<Referee> Get(){
        return _dbContext.Referees.ToList();
    }

    public async Task Update (Referee referee)
    {
        var existingReferee = await _dbContext.Referees.FindAsync(referee.RefereeId);
        if (existingReferee != null)
        {
            existingReferee.RefereeName = referee.RefereeName;
            existingReferee.DateOfBirth = referee.DateOfBirth;
            existingReferee.YearsOfExperience = referee.YearsOfExperience;

            _dbContext.Referees.Update(existingReferee);
            await _dbContext.SaveChangesAsync();
        }
    } 

    public async Task Delete (int RefereeId)
    {
        var existingReferee = await _dbContext.Referees.FindAsync(RefereeId);
        if (existingReferee != null)
        {
            _dbContext.Referees.Remove(existingReferee);
            await _dbContext.SaveChangesAsync();
        }
    } 
}
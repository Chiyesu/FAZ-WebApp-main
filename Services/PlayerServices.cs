using Data;
using Microsoft.AspNetCore.Authorization;

namespace Services;

public class PlayerServices
{
    public readonly ApplicationDatabaseContext _dbContext;
    public PlayerServices (ApplicationDatabaseContext dbContext){
        _dbContext = dbContext;
    }
    public async Task Post(Player player){
        await _dbContext.Players.AddAsync(player);
        await _dbContext.SaveChangesAsync();
    }
    public readonly List<Player> player = new List<Player>();
    public Player GetPlayerByName(string name)
    {
        return player.FirstOrDefault(p => p.PlayerName.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
    public List<Player> Get(){
        return _dbContext.Players.ToList();
    }

    public async Task Update (Player player)
    {
        var existingPlayer = await _dbContext.Players.FindAsync(player.PlayerId);
        if (existingPlayer != null)
        {
            existingPlayer.PlayerName = player.PlayerName;
            existingPlayer.DateOfBirth = player.DateOfBirth;
            existingPlayer.ShirtNumber = player.ShirtNumber;
            existingPlayer.StartYear = player.StartYear;
            existingPlayer.TeamId = player.TeamId;

            _dbContext.Players.Update(existingPlayer);
            await _dbContext.SaveChangesAsync();
        }
    } 

    public async Task Delete (int PlayerId)
    {
        var existingPlayer = await _dbContext.Players.FindAsync(PlayerId);
        if (existingPlayer != null)
        {
            _dbContext.Players.Remove(existingPlayer);
            await _dbContext.SaveChangesAsync();
        }
    }    
}
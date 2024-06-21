using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class MatchServices
    {
        private readonly ApplicationDatabaseContext _dbContext;

        public MatchServices(ApplicationDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Post(Match match)
        {
            await _dbContext.Matches.AddAsync(match);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Match match)
        {
            var existingMatch = await _dbContext.Matches.FindAsync(match.MatchId);
            if (existingMatch != null)
            {
                existingMatch.HostTeamId = match.HostTeamId;
                existingMatch.GuestTeamId = match.GuestTeamId;
                existingMatch.FinalResult = match.FinalResult;
                existingMatch.RefereeId = match.RefereeId;
                existingMatch.AssistantReferee1Id = match.AssistantReferee1Id;
                existingMatch.AssistantReferee2Id = match.AssistantReferee2Id;
                existingMatch.DatePlayed = match.DatePlayed;
                existingMatch.News = match.News;

                _dbContext.Matches.Update(existingMatch);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task Delete(int matchId)
        {
            var existingMatch = await _dbContext.Matches.FindAsync(matchId);
            if (existingMatch != null)
            {
                _dbContext.Matches.Remove(existingMatch);
                await _dbContext.SaveChangesAsync();
            }
        }

        public List<Match> Get()
        {
            return _dbContext.Matches.ToList();
        }

        public async Task<Match> GetById(int matchId)
        {
            return await _dbContext.Matches.FindAsync(matchId);
        }
    }
}

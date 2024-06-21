namespace Services
{
    public class MatchParticipationServices
    {
        private readonly ApplicationDatabaseContext _dbContext;

        public MatchParticipationServices(ApplicationDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Post(MatchParticipation matchParticipation)
        {
            await _dbContext.MatchParticipation.AddAsync(matchParticipation);
            await _dbContext.SaveChangesAsync();
        }

        public List<MatchParticipation> Get()
        {
            return _dbContext.MatchParticipation.ToList();
        }

        public async Task Update(MatchParticipation matchParticipation)
        {
            var existingParticipation = await _dbContext.MatchParticipation.FindAsync(matchParticipation.MatchParticipationId);
            if (existingParticipation != null)
            {
                existingParticipation.PlayerId = matchParticipation.PlayerId;
                existingParticipation.GoalScored = matchParticipation.GoalScored;
                existingParticipation.MatchId = matchParticipation.MatchId;
                existingParticipation.Card = matchParticipation.Card;

                _dbContext.MatchParticipation.Update(existingParticipation);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task Delete(int matchParticipationId)
        {
            var existingParticipation = await _dbContext.MatchParticipation.FindAsync(matchParticipationId);
            if (existingParticipation != null)
            {
                _dbContext.MatchParticipation.Remove(existingParticipation);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}

namespace Services

{
    public class SubstitutionServices
    {
        private readonly ApplicationDatabaseContext _dbContext;

        public SubstitutionServices(ApplicationDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Post(Substitution substitution)
        {
            await _dbContext.Substitutions.AddAsync(substitution);
            await _dbContext.SaveChangesAsync();
        }

        public List<Substitution> Get()
        {
            return _dbContext.Substitutions.ToList();
        }

        public async Task Update(Substitution substitution)
        {
            var existingSubstitution = await _dbContext.Substitutions.FindAsync(substitution.SubstitutionId);
            if (existingSubstitution != null)
            {
                existingSubstitution.MatchId = substitution.MatchId;
                existingSubstitution.PlayerInId = substitution.PlayerInId;
                existingSubstitution.PlayerOutId = substitution.PlayerOutId;
                existingSubstitution.Time = substitution.Time;

                _dbContext.Substitutions.Update(existingSubstitution);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task Delete(int substitutionId)
        {
            var existingSubstitution = await _dbContext.Substitutions.FindAsync(substitutionId);
            if (existingSubstitution != null)
            {
                _dbContext.Substitutions.Remove(existingSubstitution);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}

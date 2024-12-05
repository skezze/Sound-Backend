using Sound.Data.DbContexts;
using Sound.Data.Repositories.Interfaces;

namespace Sound.Data.Repositories;

public class SoundRepository : Repository<Core.Entities.Sound>, ISoundRepository
{
    public SoundRepository(SoundDbContext dbContext) : base(dbContext) { }
}
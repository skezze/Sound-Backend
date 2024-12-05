using Sound.Core.Entities;
using Sound.Data.DbContexts;
using Sound.Data.Repositories.Interfaces;

namespace Sound.Data.Repositories;

public class UserSoundRepository : Repository<UserSound>, IUserSoundRepository
{
    public UserSoundRepository(SoundDbContext dbContext) : base(dbContext) { }
}
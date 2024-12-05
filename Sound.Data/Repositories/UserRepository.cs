using Sound.Core.Entities;
using Sound.Data.DbContexts;
using Sound.Data.Repositories.Interfaces;

namespace Sound.Data.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(SoundDbContext dbContext) : base(dbContext){ }
}
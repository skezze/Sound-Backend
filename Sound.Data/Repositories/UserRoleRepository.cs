using Sound.Core.Entities;
using Sound.Data.DbContexts;
using Sound.Data.Repositories.Interfaces;

namespace Sound.Data.Repositories;

public class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
{
    public UserRoleRepository(SoundDbContext context) : base(context) { }
}
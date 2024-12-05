using Sound.Core.Entities;
using Sound.Data.DbContexts;
using Sound.Data.Repositories.Interfaces;

namespace Sound.Data.Repositories;

public class RoleRepository : Repository<Role>, IRoleRepository
{
    public RoleRepository(SoundDbContext context) : base(context) { }
}
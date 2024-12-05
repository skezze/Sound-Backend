using Sound.Core.Entities;
using Sound.Data.DbContexts;
using Sound.Data.Repositories.Interfaces;

namespace Sound.Data.Repositories;

public class AuthorRepository : Repository<Author>, IAuthorRepository
{
    public AuthorRepository(SoundDbContext context) : base(context)
    {
    }
}
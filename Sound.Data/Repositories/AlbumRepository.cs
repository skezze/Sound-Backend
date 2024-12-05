using Sound.Core.Entities;
using Sound.Data.DbContexts;
using Sound.Data.Repositories.Interfaces;

namespace Sound.Data.Repositories;

public class AlbumRepository : Repository<Album>,IAlbumRepository
{
    public AlbumRepository(SoundDbContext context) : base(context) { }
}
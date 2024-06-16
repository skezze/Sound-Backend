using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sound.Api.Models;
using Sound.Common.Models;

namespace Sound.Data.DbContexts
{
    public class SoundDbContext : IdentityDbContext<User>
    {
        public SoundDbContext(DbContextOptions<SoundDbContext> options) : base(options)
        { }
        public DbSet<AudioFile> AudioFiles { get; set; }
    }
}

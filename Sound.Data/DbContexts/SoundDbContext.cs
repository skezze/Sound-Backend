using Microsoft.EntityFrameworkCore;
using Sound.Core.Entities;

namespace Sound.Data.DbContexts
{
    public class SoundDbContext : DbContext
    {
        public SoundDbContext() { }
        public SoundDbContext(DbContextOptions<SoundDbContext> options) : base(options) { }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Core.Entities.Sound> Sounds { get; set; }
        public DbSet<UserSound> UserSounds { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("host=localhost;database=SoundDb;UID=postgres;PWD=postgres");
            }
        }

    }
}

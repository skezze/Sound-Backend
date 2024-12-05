using Amazon.S3;
using Microsoft.EntityFrameworkCore;
using Sound.Data.DbContexts;
using Sound.Data.Repositories;
using Sound.Data.Repositories.Interfaces;

namespace Sound.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddSingleton<IAmazonS3>(sp =>
            {
                var config = new AmazonS3Config
                {
                    ServiceURL = "http://localhost:9000",
                    ForcePathStyle = true
                };
                return new AmazonS3Client("your-access-key", "your-secret-key", config);
            });
       
        builder.Services.AddEndpointsApiExplorer();
        
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<SoundDbContext>(
                            options => options.UseNpgsql(
                                builder.Configuration.GetConnectionString("defaultConnection")));

            builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
            builder.Services.AddScoped<IRoleRepository, RoleRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ISoundRepository, SoundRepository>();
            builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            builder.Services.AddScoped<IUserSoundRepository, UserSoundRepository>();
            builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
            
            builder.Services.AddAuthorization();
            
            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<SoundDbContext>();
                db.Database.Migrate();
            }
            
            app.UseSwagger();
            app.UseSwaggerUI();

            //app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}

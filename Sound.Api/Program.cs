using Amazon.S3;
using Microsoft.EntityFrameworkCore;
using Sound.Api.Models;
using Sound.Api.Services;
using Sound.Common;
using Sound.Data.DbContexts;

namespace Sound.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDataProtection();

            builder.Services.AddControllers();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder
                        .WithOrigins(Configuration.AngularAppUrl)
                        .AllowAnyHeader()
                        .AllowAnyMethod());
            });

            builder.Services.AddSingleton<TokenService>();
            builder.Services.AddSingleton<IAmazonS3>(sp =>
            {
                var config = new AmazonS3Config
                {
                    ServiceURL = "http://localhost:9000", // URL вашего MinIO сервера
                    ForcePathStyle = true
                };
                return new AmazonS3Client("your-access-key", "your-secret-key", config);
            });
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<SoundDbContext>(
                            options => options.UseSqlServer(
                                builder.Configuration.GetConnectionString("defaultConnection")));

            builder.Services.AddAuthorization();
            builder.Services.AddIdentityApiEndpoints<User>()
                            .AddEntityFrameworkStores<SoundDbContext>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
           
                app.UseSwagger();
                app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapIdentityApi<User>();

            app.MapControllers();
            app.UseCors("AllowSpecificOrigin");

            app.Run();
        }
    }
}

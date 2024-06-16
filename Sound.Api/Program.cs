using Microsoft.EntityFrameworkCore;
using Sound.Api.Models;
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

            builder.Services.AddControllers();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder
                        .WithOrigins(Configuration.AngularAppUrl)
                        .AllowAnyHeader()
                        .AllowAnyMethod());
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
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapIdentityApi<User>();

            app.MapControllers();
            app.UseCors("AllowSpecificOrigin");

            app.Run();
        }
    }
}

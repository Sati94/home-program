
using Microsoft.EntityFrameworkCore;
using Home_Program.Data;
using Microsoft.Extensions.Configuration;

namespace Home_Program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

     
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(connectionString))
              {
                 throw new InvalidOperationException("A CONNECTION_STRING nincs beállítva az appsettings.json fájlban.");
              }

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
               options.UseNpgsql(connectionString));
            
            builder.Services.AddControllers();
           
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
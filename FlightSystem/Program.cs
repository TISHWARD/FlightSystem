
using FlightBookingSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightSystem
{
    public class Program
    {
        private static readonly object context;

        public static void Main(string[] args)

        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            var config = builder.Configuration; //Configuration
            //ADD SERVICES
            builder.Services.AddDbContext<AppDbContext>(option => {
                option.UseSqlServer(config.GetConnectionString("mycon"));

            });
            //builder.Services.AddTransient<IProduct, ProductRepo>();

            //builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

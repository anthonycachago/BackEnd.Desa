
using BackEnd.Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;
using BackEnd.Infrastructure;
using BackEnd.Bussines;
namespace BackEnd.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
         
            builder.Services.AddSwaggerGen();
            // Add services to the container.
            builder.Services.AddDbContext<BackEndContext>(options =>
           options.UseSqlServer(builder.Configuration.GetConnectionString("backendConnection")));

            builder.Services.AddRepository(); // <-- Aquí registras UnitOfWorkPaciente
            builder.Services.AddService(); // <-- Aquí registras Servicios

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

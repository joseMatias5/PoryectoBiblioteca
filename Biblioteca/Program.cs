using Biblioteca.Data;
using Biblioteca.Data.Repositories;
using Biblioteca.Domain.Interfaces;
using Data;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Biblioteca.Data.Helpers;

namespace Biblioteca
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //  Agregamos el DbContext al contenedor de dependencias
            builder.Services.AddDbContext<BibliotecaContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            //  Inyección de dependencias de tus servicios y repositorios
            builder.Services.AddTransient<Application.Interfaces.IBookManagementService, Application.Services.BookManagementService>();
            builder.Services.AddScoped<IRepository, EfRepository>();

            builder.Services.AddDbContext<BibliotecaContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("BibliotecaDb"));
                options.UseSeeding((c, t) =>
                {
                    var dataDir = Path.Combine(AppContext.BaseDirectory, "Sources");

                    ((BibliotecaContext)c).Seedwork<Book>(Path.Combine(dataDir, "books.json"));
                });
            });

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

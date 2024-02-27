using Domain.Services;
using LiteDB;
using API.Services;
using Infrastructure.Database;
using Domain.Entities;
using System.Security.Cryptography;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //DB Setup Context
            var db = new LiteDatabase(@"HelloDB.db");
            IRepository<DDDItem> repository = new DDDItemRepository(db);

            // Seeding for testing
            if (repository.GetAll().Any() == false)
            {
                populateDatabase(repository);
            }

            // Add ReportAggregate service to scope.
            builder.Services.AddScoped<IDDDService, DDDService>(f => new DDDService(repository));

            // Add services to the container.
            builder.Services.AddControllers();

            // Swagger disabled
            //builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();

            // Configure CORS to interact with Frontend.
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Origins", policy =>
                {
                    policy
                    .WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            var app = builder.Build();
            app.UseCors("Origins");
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }

        private static void populateDatabase(IRepository<DDDItem> repository)
        {
repository.Insert(
    new DDDItem(
        "Salma",
        "0654321987",
        "Femme",
        "12-03-2000",
        "Software Engineer",
        2
    ));

// Example 2
repository.Insert(
    new DDDItem(
        "Karim",
        "0712345678",
        "Homme",
        "05-09-1995",
        "Data Scientist",
        3
    ));

// Example 3
repository.Insert(
    new DDDItem(
        "Lina",
        "0632109876",
        "Femme",
        "18-07-1992",
        "UX Designer",
        4
    ));

// Example 4
repository.Insert(
    new DDDItem(
        "Youssef",
        "0798765432",
        "Homme",
        "22-11-1987",
        "Project Manager",
        5
    ));
        }
    }

}

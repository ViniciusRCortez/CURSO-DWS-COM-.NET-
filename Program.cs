using Dws.Note_one.Api.Persistence.Context;
using Dws.Note_one.Api.Persistence.Repositories;
using Dws.Note_one.Api.Persistence.Repositories.IRepositories;
using Dws.Note_one.Api.Services;
using Dws.Note_one.Api.Services.IServices;
using Dws.Note_one.Api.Mapping;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;
using AutoMapper;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        builder.Services.AddControllers();

        var connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];
        builder.Services.AddDbContext<MySQLContext>(options => options
            .UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 31))));

        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<ICategoryService, CategoryService>();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<IProductService, ProductService>();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "NoteOneAPI", Version = "v1"});
            });

        var app = builder.Build();

        var scope = app.Services.CreateScope();
        using (var context = scope.ServiceProvider.GetService<MySQLContext>())
        {
            context.Database.EnsureCreated();
        }

        // Configure the HTTP request pipeline.

        app.UseSwagger();
        app.UseSwaggerUI();

        

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}


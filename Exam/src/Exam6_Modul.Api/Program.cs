using Exam6_Modul.Api.Data;
using Microsoft.EntityFrameworkCore;
using Exam6_Modul.Api.Repositories;
using Exam6_Modul.Api.Services;
using Exam6_Modul.Api.Mapping;
using Exam6_Modul.Api.Configurations;
using Serilog;
using FluentValidation;

namespace Exam6_Modul.Api;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configure DbContext with SQL Server
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
            ?? "Server=(localdb)\\mssqllocaldb;Database=Exam6ModulDb;Trusted_Connection=True;MultipleActiveResultSets=true";
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));

        // Create Serilog logger and register with Host
        var logger = SerilogConfig.CreateLogger(builder.Configuration);
        builder.Host.UseSerilog(logger);
        builder.Services.AddSingleton<Serilog.ILogger>(logger);

        // Add services to the container and register validation filter
        builder.Services.AddScoped<ValidationFilter>();
        builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>());
        // Register FluentValidation validators explicitly
        builder.Services.AddTransient<FluentValidation.IValidator<Exam6_Modul.Api.Dtos.CategoryCreateDto>, Exam6_Modul.Api.Configurations.Validators.CategoryCreateValidator>();
        builder.Services.AddTransient<FluentValidation.IValidator<Exam6_Modul.Api.Dtos.CategoryUpdateDto>, Exam6_Modul.Api.Configurations.Validators.CategoryUpdateValidator>();
        builder.Services.AddTransient<FluentValidation.IValidator<Exam6_Modul.Api.Dtos.FoodCreateDto>, Exam6_Modul.Api.Configurations.Validators.FoodCreateValidator>();
        builder.Services.AddTransient<FluentValidation.IValidator<Exam6_Modul.Api.Dtos.FoodUpdateDto>, Exam6_Modul.Api.Configurations.Validators.FoodUpdateValidator>();
        // Register repositories, services and mappers
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<IFoodRepository, FoodRepository>();
        builder.Services.AddScoped<CategoryMapper>();
        builder.Services.AddScoped<FoodMapper>();
        builder.Services.AddScoped<ICategoryService, CategoryService>();
        builder.Services.AddScoped<IFoodService, FoodService>();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Apply migrations on startup
        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            db.Database.Migrate();
        }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        // Serilog request logging middleware (custom)
        app.UseMiddleware<Exam6_Modul.Api.Logs.RequestLoggingMiddleware>();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();

    }
}
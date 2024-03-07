using Microsoft.EntityFrameworkCore;
using Torc.API.Mappers;
using Torc.API.Mappers.Interfaces;
using Torc.API.Repositories;
using Torc.API.Repositories.Interfaces;
using Torc.API.Services;
using Torc.API.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure CORS
builder.Services.AddCors(
    options =>
    {
        options.AddPolicy("ReactCorsPolicy",
            builder =>
            {
                builder.WithOrigins("http://localhost:3000")
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            });
    });

InjectObjects(builder);
ConfigureDatabase(builder);


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

app.UseCors("ReactCorsPolicy");

app.Run();

static void InjectObjects(WebApplicationBuilder builder)
{
    builder.Services.AddScoped<IBookSearchService, BookSearchService>();
    builder.Services.AddScoped<IBookMapper, BookMapper>();
    builder.Services.AddScoped<IBookRepository, BookRepository>();
}

static void ConfigureDatabase(WebApplicationBuilder builder)
{
    builder.Services.AddDbContext<BookDbContext>(options =>
           options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    using (var serviceProvider = builder.Services.BuildServiceProvider())
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<BookDbContext>();
            try
            {
                dbContext.Database.Migrate();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error applying migrations: {ex.Message}");
            }
        }
    }
}
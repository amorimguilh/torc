using Microsoft.EntityFrameworkCore;
using Torc.API.Repositories;

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


builder.Services.AddDbContext<BookDbContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

using (var serviceProvider = builder.Services.BuildServiceProvider())
{
    using (var scope = serviceProvider.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<BookDbContext>();
        try
        {
            // dbContext.Database.Migrate();
        }
        catch (Exception ex)
        {
            // Handle migration errors
            Console.WriteLine($"Error applying migrations: {ex.Message}");
            // You might want to log the exception and handle it according to your application's needs
        }
    }
}

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

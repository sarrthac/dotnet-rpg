using dotnet_rpg.Data;
using dotnet_rpg.Services.CharacterService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Added Scope so that when Controller wants to inject the ICharacterService then corresponding implementation class would be CharacterService
builder.Services.AddScoped<ICharacterService, CharacterService>();

//Registering AutoMapper
builder.Services.AddAutoMapper(typeof(IStartup));

//Automatically configures the requirements of AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Connection with Db
builder.Services.AddDbContext<DataContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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

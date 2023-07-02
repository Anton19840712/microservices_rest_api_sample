using Microsoft.EntityFrameworkCore;
using PlatformService.Data;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

Console.WriteLine("--> Using InMem Db");
services.AddDbContext<AppDbContext>(opt =>
	opt.UseInMemoryDatabase("InMem"));

services.AddScoped<IPlatformRepo, PlatformRepo>();

var app = builder.Build();

PrepDb.PrepPopulation(app, true);

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

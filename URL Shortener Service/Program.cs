using Microsoft.EntityFrameworkCore;
using URL_Shortener_Service.Application_Layer;
using URL_Shortener_Service.Domain_Layer;
using URL_Shortener_Service.Infrastructure_Layer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<UrlShortenerDbContext>(options =>
		options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IURLMappingRepository, UrlMappingRepository>();
builder.Services.AddScoped<IUrlShortenerService, UrlShortenerService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

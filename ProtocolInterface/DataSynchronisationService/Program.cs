using Microsoft.Data.SqlClient;
using System.Data;

using DataSynchronisationService.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add dependency injection for IDatabase and IDbConnection
/*
	AddSingleton	- same instance for every request
	AddScoped		- creates instance once per client request
	Transient		- new instance created every time
*/
builder.Services.AddScoped<IDatabase, ContrOCCDatabase>();
var connectionString = builder.Configuration.GetConnectionString("ContrOCC");
builder.Services.AddTransient<IDbConnection, SqlConnection>((x) => new SqlConnection(connectionString));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
else
{
	// Only use HTTPS in production
	app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

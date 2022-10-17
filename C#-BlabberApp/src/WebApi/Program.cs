using DataStore.Plugins;

using Domain.Common.Interfaces;

const string dsn = "server=143.110.159.170;uid=cyoungberg1;pwd=letmein;database=cyoungberg1";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// builder.Services.AddSingleton<IBlabRepository, InMemBlabRepository>();
builder.Services.AddSingleton<IBlabRepository, MySqlBlabRepository>(r => new MySqlBlabRepository(dsn));
builder.Services.AddSingleton<IUserRepository, MySqlUserRepository>(r => new MySqlUserRepository(dsn));

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

// app.UseAuthorization();

app.MapControllers();

app.Run();
using Domain.Common.Interfaces;
using DataStore.Plugins;

var builder = WebApplication.CreateBuilder(args);
var dsn = "server=143.110.159.170;uid=cyoungberg1;pwd=letmein;database=cyoungberg1";

// Add services to the container.
builder.Services.AddRazorPages();

// Dependency Injection Container LOL
//builder.Services.AddSingleton<IUserRepository, InMemUserRepository>();
//builder.Services.AddSingleton<IBlabRepository, InMemBlabRepository>();
builder.Services.AddSingleton<IBlabRepository, MySqlBlabRepository>(r => new MySqlBlabRepository(dsn));
builder.Services.AddSingleton<IUserRepository, MySqlUserRepository>(r => new MySqlUserRepository(dsn));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

// app.UseAuthorization();

app.MapRazorPages();

app.Run();
using AgnostiQ_BI.Components;
using AgnostiQ_BI.Features.TimeSeriesAnalytics.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "Server=localhost;Port=3306;Database=agnostiq_bi;User=root;Password=;";

builder.Services.AddDbContext<AppDbContext>(options=>
options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<AgnostiQ_BI.Components.App>()
    .AddInteractiveServerRenderMode();

app.Run();

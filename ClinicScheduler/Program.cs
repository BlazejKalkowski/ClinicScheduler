using System.Security.Claims;
using ClinicScheduler;
using ClinicScheduler.Components;
using ClinicScheduler.Entities;
using ClinicScheduler.Interfaces;
using ClinicScheduler.Middleware;
using ClinicScheduler.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.JSInterop;
using MudBlazor.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Antiforgery;

var builder = WebApplication.CreateBuilder(args);

IConfigurationRoot configuration = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json",optional: true, reloadOnChange: true)
    .Build();

builder.Services.AddServerSideBlazor().AddCircuitOptions(o =>
{
    if (builder.Environment.IsDevelopment()) //only add details when debugging
    {
        o.DetailedErrors = true;
    }
});
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IVisitService, VisitService>();

builder.Services.AddHttpClient("ClinicScheduler").AddHttpMessageHandler<AccessTokenMessageHandler>();
builder.Services.AddScoped<AccessTokenMessageHandler>();
builder.Services.AddScoped<CustomAuthenticateStateProvider>();

builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorizationBuilder();
var connectionString = configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ClinicDbContext>(options =>
{
    options.UseNpgsql(connectionString);
});

builder.Services.AddIdentityCore<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
        .AddEntityFrameworkStores<ClinicDbContext>()
        .AddApiEndpoints();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddScoped<ProtectedSessionStorage>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMudServices();
builder.Services.Configure<AntiforgeryOptions>(options =>
{
    options.SuppressXFrameOptionsHeader = true;
});
var app = builder.Build();

app.UseAntiforgery();
app.UseSwagger();
app.UseSwaggerUI();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseAuthentication();
app.UseAntiforgery();
app.MapIdentityApi<IdentityUser>();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();


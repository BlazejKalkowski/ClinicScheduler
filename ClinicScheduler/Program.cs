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

var builder = WebApplication.CreateBuilder(args);

IConfigurationRoot configuration = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json",optional: true, reloadOnChange: true)
    .Build();

builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IVisitService, VisitService>();

builder.Services.AddHttpClient("HttpMessageHandler").AddHttpMessageHandler<AccessTokenMessageHandler>();
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
builder.Services.AddScoped<IJSRuntime>();
builder.Services.AddScoped<AuthenticationStateProvider,CustomAuthenticateStateProvider>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();


app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapIdentityApi<IdentityUser>();
// app.MapGet("/test", (ClaimsPrincipal user) => $"Hello {user.Identity!.Name}").RequireAuthorization();
app.Run();


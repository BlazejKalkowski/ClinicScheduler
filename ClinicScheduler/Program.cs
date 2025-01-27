using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using ClinicScheduler;
using ClinicScheduler.Components;
using ClinicScheduler.Interfaces;
using ClinicScheduler.Middleware;
using ClinicScheduler.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

IConfigurationRoot configuration = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json",optional: true, reloadOnChange: true)
    .Build();

builder.Services.AddServerSideBlazor().AddCircuitOptions(o =>
{
    if (builder.Environment.IsDevelopment())
    {
        o.DetailedErrors = true;
    }
});
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IVisitService, VisitService>();


builder.Services.AddScoped<AccessTokenMessageHandler>();
builder.Services.AddScoped<CustomAuthenticateStateProvider>();

builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorizationBuilder();



builder.Configuration.AddAzureKeyVault($"https://{builder.Configuration["ClinicDBKey"]}.vault.azure.net/", new DefaultKeyVaultSecretManager());

var client = new SecretClient(new Uri($"https://{builder.Configuration["ClinicDBKey"]}.vault.azure.net/"), new DefaultAzureCredential());

builder.Services.AddDbContext<ClinicDbContext>(options =>
{
    options.UseSqlServer(client.GetSecret("DbKey").Value.Value.ToString());
});

builder.Services.AddIdentityCore<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
        .AddEntityFrameworkStores<ClinicDbContext>()
        .AddApiEndpoints();
builder.Services.AddRazorPages();
// Add services to the container.
builder.Services.AddRazorComponents()
        .AddInteractiveServerComponents();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRadzenComponents();
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<ContextMenuService>();
builder.Services.AddScoped<ContextMenuService>();
builder.Services.AddScoped<TooltipService>();
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

app.UseAuthorization();
app.UseAntiforgery();
app.MapRazorPages();
app.UseStaticFiles();
app.MapGroup("api/auth")
    .MapIdentityApi<IdentityUser>();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();


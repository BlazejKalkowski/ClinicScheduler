using ClinicScheduler;
using ClinicScheduler.Components;
using ClinicScheduler.Interfaces;
using ClinicScheduler.Middleware;
using ClinicScheduler.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Radzen;

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


// var baseUri = builder.Configuration.GetValue<string>("BaseUri");

// builder.Services.AddScoped(sp => new HttpClient
// {
//     BaseAddress = new Uri(baseUri)
// });


// builder.Services.AddHttpClient("api").AddHttpMessageHandler<AccessTokenMessageHandler>();


// builder.Services.AddHttpClient("api", 
//         client => client.BaseAddress = new Uri(baseUri))
//     .AddHttpMessageHandler<AccessTokenMessageHandler>();
//
// builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
//     .CreateClient("api"));

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


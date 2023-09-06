using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using the_squad_server.API;
using the_squad_server.Areas.Identity;
using the_squad_server.Data;
using the_squad_server.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseSqlite(connectionString));  
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<UserDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
builder.Services.AddAuthentication()
   .AddMicrosoftAccount(microsoftOptions =>
   {
       microsoftOptions.ClientId = builder.Configuration["Authentication:Microsoft:ClientId"];
       microsoftOptions.ClientSecret = builder.Configuration["Authentication:Microsoft:ClientSecret"];
   });

builder.Services.AddSingleton<APIService<Server>>(provider =>
    ActivatorUtilities.CreateInstance<APIService<Server>>(provider, builder.Configuration["Authentication:API:ClientSecret"])
);


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));  
builder.Services.AddScoped<CreatorManager<Creator>>();
builder.Services.AddScoped<GameManager<Game>>();
builder.Services.AddScoped<StreamingServiceManager<StreamingService>>();
builder.Services.AddScoped<ServerManager<Server>>();
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Remove for Production
app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
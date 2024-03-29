using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProiectWeb.Data;
using Microsoft.AspNetCore.Identity;
using ProiectWeb.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
   policy.RequireRole("Admin"));
});


// Add services to the container.
builder.Services.AddRazorPages(options => { options.Conventions.AuthorizeFolder("/Membrii");
    options.Conventions.AuthorizeFolder("/Inscrieri");
    options.Conventions.AuthorizeFolder("/Participari");
});
builder.Services.AddDbContext<ProiectWebContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProiectWebContext") ?? throw new InvalidOperationException("Connection string 'ProiectWebContext' not found.")));

builder.Services.AddDbContext<GymIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProiectWebContext") ?? throw new InvalidOperationException("Connection string 'ProiectWebContext' not found.")));

builder.Services.AddDefaultIdentity<GymUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>().AddEntityFrameworkStores<GymIdentityContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();

using Alachisoft.NCache.AspNetCore.SignalR;
using gh_signalr_demo.Hubs;
using gh_signalr_demo.Repositories;
using ProtoBuf.Extended.Meta;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSignalR(o => o.EnableDetailedErrors = true);
builder.Services.AddSingleton<IFarmTempRepo, FarmMemoryRepo>();
ConfigurationManager configuration = builder.Configuration;
builder.Services.AddSignalR().AddNCache(ncacheOptions => {
    ncacheOptions.CacheName = configuration["NCacheConfiguration:CacheName"];
    ncacheOptions.EventKey = configuration["NCacheConfiguration:ApplicationID"];
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapPost("farm/{farmId}/farmTemp", (int farmId, int farmTemp, IFarmTempRepo auctionRepo) =>
{
    auctionRepo.NewTemperature(farmId, farmTemp);
});

app.MapHub<FarmHub>("/farmhub");
app.Run();

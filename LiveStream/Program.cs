using AngryMonkey.CloudWeb;
using LiveStream.Services;
using Microsoft.Extensions.FileProviders;
using System.Reflection.Metadata;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


CloudWebConfig cloudWeb = new()
{
    PageDefaults = new()
    {
        Title = "Coverbox Live",
        Bundles = new()
         {
         new(){ Source = "css/site.css"},
         new(){ Source = "js/site.js"},
         },
        TitleAddOns = new()
        {

        }
    },
    TitleSuffix = " - Coverbox Live",
};

builder.Services.AddCloudWeb(cloudWeb);

builder.Services.AddSingleton(
    sp =>
        {
            return new ChannelServices(builder.Configuration["stream:url"]);
        }
 );

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
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "node_modules")),
    RequestPath = new PathString("/vendor")
});
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

await app.RunAsync();

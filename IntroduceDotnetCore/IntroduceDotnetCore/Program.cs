var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();


var app = builder.Build();
//Ctrl K+C
app.UseRouting();

app.MapControllerRoute(name: "default",
                       pattern: "{controller=Cemil}/{action=Orhan}/{ad?}");

app.Run();
//Ctrl+shift+B
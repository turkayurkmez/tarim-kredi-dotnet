var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();


var app = builder.Build();

var message = builder.Configuration.GetValue<string>("Info:Message");
app.Logger.LogInformation($"Gelen mesaj: {message}");

//Ctrl K+C
app.UseRouting();

app.MapControllerRoute(name: "default",
                       pattern: "{controller=Cemil}/{action=Orhan}/{ad?}");

app.Run();
//Ctrl+shift+B
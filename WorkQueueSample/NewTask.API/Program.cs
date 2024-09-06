using NewTask.API.Services;
using System.IO.Compression;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddScoped<INewTaskSender, NewTaskSender_FirstOne>(x => new NewTaskSender_FirstOne("my_queue", x.GetRequiredService<ILogger<NewTaskSender_FirstOne>>()));

builder.Services.Configure<RabbitConnectionOptions>(builder.Configuration.GetSection("RabbitMQSettings"));
builder.Services.AddSingleton<RabbitConnector>();
builder.Services.AddScoped<INewTaskSender, NewTaskSender>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

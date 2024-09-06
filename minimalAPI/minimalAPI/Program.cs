using Microsoft.EntityFrameworkCore;
using minimalAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("db");
builder.Services.AddDbContext<TasksDbContext>(option=>option.UseSqlServer(connectionString));

var app = builder.Build();

app.MapGet("/todoItems",async (TasksDbContext db)=>{
    return await  db.Todos.ToListAsync();
});

app.MapGet("/todoItems/complete", async (TasksDbContext db) => 
await db.Todos.Where(t => t.IsComplete).ToListAsync());

app.MapGet("/todoItems/{id}", async (int id, TasksDbContext db) =>
    await db.Todos.FindAsync(id) is Todo todo
                                 ? Results.Ok(todo)
                                 : Results.NotFound()
);

app.MapPost("/todoItems", async (Todo todo, TasksDbContext db) =>
{
    db.Todos.Add(todo);
    await db.SaveChangesAsync();
    return Results.Created($"/todoItems/{todo.Id}", todo);
});

app.MapPut("/todoItems/{id}", async (int id, Todo todo, TasksDbContext db) =>
{
    var todoItem = await db.Todos.FindAsync(id);
    if(todoItem is null) return Results.NotFound();
    todoItem.Name = todo.Name;
    todoItem.IsComplete = todo.IsComplete;
    await db.SaveChangesAsync();
    return Results.NoContent();

});

app.MapDelete("/todoItems/{id}", async (int id, TasksDbContext db) =>
{
    if (await db.Todos.FindAsync(id) is Todo todo)
    {
        db.Todos.Remove(todo);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }
    return Results.NotFound();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.Run();



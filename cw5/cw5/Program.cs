using cw5;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddSingleton<IAnimalDb, AnimalDb>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

var visits = new List<Visit>()
{
    new Visit
    {
        Data = DateTime.Today,
        AnimalId = 1,
        Cena = 5.99,
        Opis = "opis"
    }
};

app.MapGet("api/visits", () => Results.Ok(visits))
    .WithName("GetVisits")
    .WithOpenApi();

app.MapGet("api/visits/{animalId:int}", (int animalId) =>
    {
        var result = visits.FindAll(visit => visit.AnimalId == animalId);
        if (result.Count == 0) return Results.NotFound();
        return Results.Ok(result);
    })
    .WithName("GetVisitsByAnimalId")
    .WithOpenApi();


app.MapPost("api/visits", (Visit visit) =>
    {
        visits.Add(visit);
        return Results.NoContent();
    })
    .WithName("CreateVisit")
    .WithOpenApi();

app.Run();
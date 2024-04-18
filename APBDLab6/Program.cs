using APBDLab6;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(new AnimalController("Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=animals;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

Endpoints endpoints = new Endpoints(app.Services.GetRequiredService<AnimalController>());
endpoints.MapEndpoints(app);

app.Run();

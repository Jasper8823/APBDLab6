using APBDLab6;

public class Endpoints
{
    private readonly AnimalController _animelController;

    public Endpoints(AnimalController animelController)
    {
        _animelController = animelController;
    }

    public void MapEndpoints(WebApplication app)
    {
        app.MapGet("/api/animals", () =>
        {
            var animals = _animelController.GetAllAnimals();
            return Results.Ok(animals);
        });

        app.MapPost("/api/animals", (Animal animal) =>
        {
            _animelController.AddAnimal(animal);
            return Results.Created($"/api/animals/{animal.Id}", animal);
        });

        app.MapPut("/api/animals/{id}", (int id, Animal animal) =>
        {
            _animelController.UpdateAnimal(id, animal);
            return Results.Ok();
        });

        app.MapDelete("/api/animals/{id}", (int id) =>
        {
            _animelController.DeleteAnimal(id);
            return Results.Ok();
        });
    }
}
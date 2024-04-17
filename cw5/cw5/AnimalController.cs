using Microsoft.AspNetCore.Mvc;

namespace cw5;

[ApiController]
[Route("api/animal")]
public class AnimalController : ControllerBase
{
    private IAnimalDb _animalDb;

    public AnimalController(IAnimalDb animalDb)
    {
        _animalDb = animalDb;
    }

    [HttpGet]
    public IActionResult GetAnimals()
    {
        return Ok(_animalDb.GetAnimals());
    }

    [HttpGet("{id:int}")]
    public IActionResult GetAnimalDetails(int id)
    {
        var animal = _animalDb.GetAnimalDetails(id);
        if (animal is null) return NotFound();
        return Ok(animal);
    }

    [HttpPost]
    public IActionResult CreateAnimal(Animal animal)
    {
        _animalDb.AddAnimal(animal);
        return Created($"api/animals/{animal.Id}", animal);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal(int id, Animal animal)
    {
        if (_animalDb.DeleteAnimal(id) is null) return NotFound();
        _animalDb.AddAnimal(animal);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        var animal = _animalDb.DeleteAnimal(id);
        if (animal is null) return NotFound();
        return NoContent();
    }
}
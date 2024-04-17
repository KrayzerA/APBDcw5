namespace cw5;

public interface IAnimalDb
{
    ICollection<Animal> GetAnimals();
    Animal? GetAnimalDetails(int id);
    Animal? AddAnimal(Animal animal);
    Animal? DeleteAnimal(int id);
}

public class AnimalDb : IAnimalDb
{
    private ICollection<Animal> _animals;

    public AnimalDb()
    {
        _animals = new List<Animal>
        {
            new Animal
            {
                Id = 1,
                Imie = "Szarik",
                Kategoria = "pies",
                Masa = 4.45,
                KolorSiersci = "Czarny"
            },
            new Animal
            {
                Id = 2,
                Imie = "Puszok",
                Kategoria = "kot",
                Masa = 3.95,
                KolorSiersci = "Bialy"
            }
        };
    }

    public ICollection<Animal> GetAnimals()
    {
        return _animals;
    }

    public Animal? GetAnimalDetails(int id)
    {
        return _animals.FirstOrDefault(animal => animal.Id == id);
    }

    public Animal? AddAnimal(Animal animal)
    {
        _animals.Add(animal);
        return animal;
    }

    public Animal? DeleteAnimal(int id)
    {
        var animal = _animals.FirstOrDefault(animal => animal.Id == id);
        if (animal is null) return null;
        _animals.Remove(animal);
        return animal;
    }
}
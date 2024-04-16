namespace cw5;

public class Animal
{
    public string Id { get; set; }
    public string Imie { get; set; }
    public Kategoria Kategoria { get; set; }
    public double Masa { get; set; }
    public string KolorSiersci { get; set; }

    public Animal(string id, string imie, Kategoria kategoria, double masa, string kolorSiersci)
    {
        Id = id;
        Imie = imie;
        Kategoria = kategoria;
        Masa = masa;
        KolorSiersci = kolorSiersci;
    }
}

public enum Kategoria
{
    KOT,PIES
}
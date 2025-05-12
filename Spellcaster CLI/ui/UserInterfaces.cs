public class UserInterfaces
{
    public void Menu()
    {
        Console.Clear();
        Console.WriteLine("==== SpellCaster CLI ====");
        Console.WriteLine("1. Correction d'un texte");
        Console.WriteLine("2. Traduction US UK");
        Console.WriteLine("3. Génération HTML");
        Console.WriteLine("0. Quitter");
        Console.Write("> ");
    }

    public void Correction()
    {
        Console.Clear();
        Console.WriteLine("Vous avez choisi : Correction d'un texte");
        Console.WriteLine("Entrez le texte à corriger :");
        Console.Write("> ");
    }

    public void Traduction(string nb)
    {
        Console.Clear();
        Console.WriteLine($"Vous avez choisi : Traduction {(nb == "1" ? "US" : "UK")}");
        Console.WriteLine("Entrez le texte à traduire :");
        Console.Write("> ");
    }

    public void US_UK()
    {
        Console.Clear();
        Console.WriteLine("Entrez la langue de traduction :");
        Console.WriteLine("1. Traduction en US");
        Console.WriteLine("2. Traduction en UK");
        Console.Write("> ");
    }

    public void HTML()
    {
        Console.Clear();
        Console.WriteLine("Entrez le thème :");
        Console.WriteLine("1. Santé");
        Console.WriteLine("2. Informatique");
        Console.WriteLine("3. Economie");
        Console.WriteLine("4. Environnement");
        Console.WriteLine("5. Culture");
        Console.Write("> ");
    }
}
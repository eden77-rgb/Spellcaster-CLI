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
        Console.WriteLine("Entrez le texte à corriger :");
        Console.Write("> ");
    }
}
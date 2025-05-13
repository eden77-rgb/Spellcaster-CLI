class UserInterfacesErreur
{
    public void ErreurChoix()
    {
        Console.WriteLine("[ERREUR]: Option invalide. Veuillez entrer une valeur correspondant à une option.");
    }

    public void ErreurCleAPI(string cleAPI, string nomCleAPI)
    {
        try
        {
            if (string.IsNullOrEmpty(cleAPI))
            {
                throw new InvalidOperationException($"[ERREUR]: Clé API {nomCleAPI} manquante ou mal configurée");
            }
        }

        catch (InvalidOperationException e)
        {
            Console.WriteLine(e.Message);
            Environment.Exit(1);
        }
    }

    public void ErreurFilePath(string filePath, string nomFichier)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("[ERREUR]: Le chemin fourni est vide ou invalide");
            }

            if (!(File.Exists(filePath)))
            {
                throw new FileNotFoundException($"[ERREUR]: Fichier {nomFichier} introuvable au chemin {filePath}");
            }
        }

        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
            Environment.Exit(1);
        }

        catch (FileNotFoundException e)
        {
            Console.WriteLine(e.Message);
            Environment.Exit(1);
        }
    }

    public void ErreurDirectoryPath(string direcoryPath)
    {
        if (!(Directory.Exists(direcoryPath)))
        {
            Console.WriteLine("Création du dossier output...");
            Directory.CreateDirectory("output");
        }
    }

    public bool ErreurFileExists(string filePath)
    {
        if (File.Exists(filePath))
        {
            Console.Write($"[AVERTISSEMENT]: Le fichier {filePath} est deja existant. ");
            Console.WriteLine("Cette action entraînera la suppression de fichiers existants. Confirmez-vous (O/N) ?");
            Console.Write("> ");
            string choix = Console.ReadLine().Trim();

            if (choix == "O")
            {
                Console.WriteLine($"[INFO]: Le fichier {filePath} sera remplacé");
                File.Delete(filePath);
                return true;
            }

            else if (choix == "N")
            {
                Console.WriteLine("[INFO]: Opération annulée par l'utilisateur.");
                return false;
            }

            else
            {
                ErreurChoix();
                return ErreurFileExists(filePath);
            }
        }

        return true;
    }

    public string ChoixDictionaire(Dictionary<string, string> themes)
    {
        string choix;
        do
        {
            Console.Write("> ");
            choix = Console.ReadLine().Trim();

            if (!themes.ContainsKey(choix))
            {
                ErreurChoix();
            }

        } while (!themes.ContainsKey(choix));

        return choix;
    }
}
class UserIntefacesArgs
{
    public async Task gestionArgs(string[] args, Dictionary<string, string> theme, HtmlGenerator html, UserInterfaces affichage, UserInterfacesErreur erreur, NewsAPIService newsAPI)
    {
        if (args.Length == 1)
        {
            if (args[0] == "-news")
            {
                Console.WriteLine("[AVERTISSEMENT]: Il vous manque un argument pour le thème des news");
                Console.WriteLine("Entrez l'argument manquant");
                Console.Write("> ");
                string argument = Console.ReadLine();

                if (theme.ContainsKey(argument))
                {
                    await html.Generate(theme[argument], newsAPI, erreur);

                    affichage.Lancer();
                    string choixLancer = Console.ReadLine();

                    if (choixLancer == "O")
                    {
                        html.Run(theme[argument]);
                    }

                    affichage.Suite();
                }
            }
        }

        else if (args.Length == 2)
        {
            if (args[0] == "-news")
            {
                if (theme.ContainsKey(args[1]))
                {
                    await html.Generate(theme[args[1]], newsAPI, erreur);

                    affichage.Lancer();
                    string choixLancer = Console.ReadLine();

                    if (choixLancer == "O")
                    {
                        html.Run(theme[args[1]]);
                    }

                    affichage.Suite();
                }
            }
        }

        else if (args.Length == 3)
        {
            if (args[0] == "-news")
            {
                if (theme.ContainsKey(args[1]))
                {
                    await html.Generate(theme[args[1]], newsAPI, erreur);

                    if (args[2] == "-o")
                    {
                        html.Run(theme[args[1]]);
                    }

                    affichage.Suite();
                }
            }
        }
    }
}
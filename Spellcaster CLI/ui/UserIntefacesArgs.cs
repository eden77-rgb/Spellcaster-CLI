using TextCopy;

class UserIntefacesArgs
{
    public async Task gestionArgs(string[] args, Dictionary<string, string> theme, HtmlGenerator html, UserInterfaces affichage, UserInterfacesErreur erreur, NewsAPIService newsAPI, OpenAIService openAI, string Correction, string TraductionUS, string TraductionUK)
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

            if (args[0] == "-correct")
            {
                Console.WriteLine("[AVERTISSEMENT]: Il vous manque un argument pour le texte à corriger");
                Console.WriteLine("Entrez l'argument manquant");
                Console.Write("> ");
                string texte = Console.ReadLine();

                string texteCorriger = openAI.getData(openAI.getPrompt(Correction, texte));
                Console.WriteLine($"[ASSISTANT]: {texteCorriger}");

                ClipboardService.SetText(texteCorriger);
                Console.WriteLine("[INFO]: Le texte corrigé a été copié avec succès");

                affichage.Suite();
            }

            if (args[0] == "-trad")
            {
                Console.WriteLine("[AVERTISSEMENT]: Il vous manque un argument pour la langue de traduction");
                Console.WriteLine("Entrez l'argument manquant");
                Console.Write("> ");
                string choixUsUk = Console.ReadLine();

                Console.WriteLine("[AVERTISSEMENT]: Il vous manque un argument pour le texte à traduire");
                Console.WriteLine("Entrez l'argument manquant");
                Console.Write("> ");
                string texte = Console.ReadLine();

                string texteTraduit = openAI.getData(openAI.getPrompt((choixUsUk == "-us" ? TraductionUS : TraductionUK), texte));
                Console.WriteLine($"[ASSISTANT]: {texteTraduit}");

                ClipboardService.SetText(texteTraduit);
                Console.WriteLine("[INFO]: Le texte traduit a été copié avec succès");

                affichage.Suite();
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

            if (args[0] == "-correct")
            {
                string texteCorriger = openAI.getData(openAI.getPrompt(Correction, args[1]));
                Console.WriteLine($"[ASSISTANT]: {texteCorriger}");

                ClipboardService.SetText(texteCorriger);
                Console.WriteLine("[INFO]: Le texte corrigé a été copié avec succès");

                affichage.Suite();
            }

            if (args[0] == "-trad")
            {
                if (args[1] == "-us" || args[1] == "-uk")
                {
                    Console.WriteLine("[AVERTISSEMENT]: Il vous manque un argument pour le texte à traduire");
                    Console.WriteLine("Entrez l'argument manquant");
                    Console.Write("> ");
                    string texte = Console.ReadLine();

                    string texteTraduit = openAI.getData(openAI.getPrompt((args[1] == "-us" ? TraductionUS : TraductionUK), texte));
                    Console.WriteLine($"[ASSISTANT]: {texteTraduit}");

                    ClipboardService.SetText(texteTraduit);
                    Console.WriteLine("[INFO]: Le texte traduit a été copié avec succès");
                }

                affichage.Suite();
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

            if (args[0] == "-trad")
            {
                if (args[1] == "-us" || args[1] == "-uk")
                {
                    string texteTraduit = openAI.getData(openAI.getPrompt((args[1] == "-us" ? TraductionUS : TraductionUK), args[2]));
                    Console.WriteLine($"[ASSISTANT]: {texteTraduit}");

                    ClipboardService.SetText(texteTraduit);
                    Console.WriteLine("[INFO]: Le texte traduit a été copié avec succès");
                }

                affichage.Suite();
            }
        }
    }
}
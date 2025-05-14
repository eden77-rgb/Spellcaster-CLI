using System.Threading.Tasks;
using dotenv.net;
using TextCopy;

class Program 
{
    private const string PATH_ENV = ".env";
    private static Dictionary<string, string> theme = new Dictionary<string, string>
    {
        { "1", "business" },
        { "2", "entertainment" },
        { "3", "general" },
        { "4", "health" },
        { "5", "science" },
        { "6", "sports" },
        { "7", "technology" },
    };

    [STAThread]
    public static async Task Main(string[] args)
    {
        UserInterfaces affichage = new UserInterfaces();
        UserInterfacesErreur erreur = new UserInterfacesErreur();
        PromptType prompt = new PromptType();
        HtmlGenerator html = new HtmlGenerator();

        erreur.ErreurFilePath(PATH_ENV, ".env");

        DotEnv.Load(options: new DotEnvOptions(envFilePaths: new[] { PATH_ENV }));
        string openAIApiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
        string newsAPIApiKey = Environment.GetEnvironmentVariable("NEWSAPI_API_KEY");

        erreur.ErreurCleAPI(openAIApiKey, "OpenAI");
        erreur.ErreurCleAPI(newsAPIApiKey, "NewsAPI");

        OpenAIService openAI = new OpenAIService(openAIApiKey);
        NewsAPIService newsAPI = new NewsAPIService(newsAPIApiKey);

        var Correction = prompt.Prompt()[PromptType.Type.Correction];
        var TraductionUS = prompt.Prompt()[PromptType.Type.TraductionUS];
        var TraductionUK = prompt.Prompt()[PromptType.Type.TraductionUK];

        bool running = true;
        while (running)
        {
            affichage.Menu();
            string choix = Console.ReadLine();

            if (choix == "1")
            {
                affichage.Correction();
                string texte = Console.ReadLine();

                string texteCorriger = openAI.getData(openAI.getPrompt(Correction, texte));
                Console.WriteLine($"[ASSISTANT]: {texteCorriger}");

                ClipboardService.SetText(texteCorriger);
                Console.WriteLine("[INFO]: Le texte corrigé a été copié avec succès");

                affichage.Suite();
            }

            else if (choix == "2")
            {
                affichage.US_UK();
                string choixUsUk = Console.ReadLine();

                affichage.Traduction(choixUsUk);
                string texte = Console.ReadLine();

                string texteTraduit = openAI.getData(openAI.getPrompt((choixUsUk == "1" ? TraductionUS : TraductionUK), texte));
                Console.WriteLine($"[ASSISTANT]: {texteTraduit}");

                ClipboardService.SetText(texteTraduit);
                Console.WriteLine("[INFO]: Le texte traduit a été copié avec succès");

                affichage.Suite();
            }

            else if (choix == "3")
            {
                affichage.HTML();
                string choixTheme = erreur.ChoixDictionaire(theme);

                affichage.Creation(theme[choixTheme]);
                await html.Generate(theme[choixTheme], newsAPI, erreur);

                affichage.Lancer();
                string choixLancer = Console.ReadLine();

                if (choixLancer == "O")
                {
                    html.Run(theme[choixTheme]);
                }

                affichage.Suite();
            }

            else if (choix == "0")
            {
                affichage.Fin();
                running = false;
            }

            else
            {
                erreur.ErreurChoix();
                affichage.Suite();
            }
        }
    }
}

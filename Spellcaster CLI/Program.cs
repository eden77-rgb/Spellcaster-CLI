using System.Threading.Tasks;
using dotenv.net;

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

    public static async Task Main(string[] args)
    {
        DotEnv.Load(options: new DotEnvOptions(envFilePaths: new[] { PATH_ENV }));
        string openAIApiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
        string newsAPIApiKey = Environment.GetEnvironmentVariable("NEWSAPI_API_KEY");

        UserInterfaces affichage = new UserInterfaces();
        OpenAIService openAI = new OpenAIService(openAIApiKey);
        PromptType prompt = new PromptType();
        NewsAPIService newsAPI = new NewsAPIService(newsAPIApiKey);
        HtmlGenerator html = new HtmlGenerator();

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

                Console.WriteLine($"[ASSISTANT]: {openAI.getData(openAI.getPrompt(Correction, texte))}");
                affichage.Suite();
            }

            else if (choix == "2")
            {
                affichage.US_UK();
                string choixUsUk = Console.ReadLine();

                affichage.Traduction(choixUsUk);
                string texte = Console.ReadLine();

                Console.WriteLine($"[ASSISTANT]: {openAI.getData(openAI.getPrompt((choixUsUk == "1" ? TraductionUS : TraductionUK), texte))}");
                affichage.Suite();
            }

            else if (choix == "3")
            {
                affichage.HTML();
                string choixTheme = Console.ReadLine();

                affichage.Creation(theme[choixTheme]);
                await html.Generate(theme[choixTheme], newsAPI);
                Console.WriteLine("Fichier créer avec succès");

                affichage.Suite();
            }

            else if (choix == "0")
            {
                affichage.Fin();
                running = false;
            }
        }
    }
}

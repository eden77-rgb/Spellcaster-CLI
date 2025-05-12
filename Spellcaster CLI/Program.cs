using dotenv.net;

class Program 
{
    private const string PATH_ENV = ".env";

    public static void Main(string[] args)
    {
        DotEnv.Load(options: new DotEnvOptions(envFilePaths: new[] { PATH_ENV }));
        string openAIApiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
        string newsAPIApiKey = Environment.GetEnvironmentVariable("NEWSAPI_API_KEY");

        UserInterfaces affichage = new UserInterfaces();
        OpenAIService openAI = new OpenAIService(openAIApiKey);
        PromptType prompt = new PromptType();
        NewsAPIService newsAPI = new NewsAPIService(newsAPIApiKey);

        var Correction = prompt.Prompt()[PromptType.Type.Correction];
        var TraductionUS = prompt.Prompt()[PromptType.Type.TraductionUS];
        var TraductionUK = prompt.Prompt()[PromptType.Type.TraductionUK];

        affichage.Menu();
        string choix = Console.ReadLine();

        if (choix == "1")
        {
            affichage.Correction();
            string texte = Console.ReadLine();

            Console.WriteLine($"[ASSISTANT]: {openAI.getData(openAI.getPrompt(Correction, texte))}");
        }

        else if (choix == "2")
        {
            affichage.US_UK();
            string choixUsUk = Console.ReadLine();

            affichage.Traduction(choixUsUk);
            string texte = Console.ReadLine();

            Console.WriteLine($"[ASSISTANT]: {openAI.getData(openAI.getPrompt((choixUsUk == "1" ? TraductionUS : TraductionUK), texte))}");
        }

        else if (choix == "3")
        {
            Console.WriteLine($"Titre : {newsAPI.getTitre("technology", 0)}");
            Console.WriteLine($"Description : {newsAPI.getDescription("technology", 0)}");
        }
    }
}

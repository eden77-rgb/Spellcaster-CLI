using dotenv.net;

class Program 
{
    private const string PATH_ENV = ".env";

    public static void Main(string[] args)
    {
        DotEnv.Load(options: new DotEnvOptions(envFilePaths: new[] { PATH_ENV }));
        string apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");

        UserInterfaces affichage = new UserInterfaces();
        OpenAIService service = new OpenAIService(apiKey);
        PromptType prompt = new PromptType();

        var Correction = prompt.Prompt()[PromptType.Type.Correction];
        var TraductionUS = prompt.Prompt()[PromptType.Type.TraductionUS];
        var TraductionUK = prompt.Prompt()[PromptType.Type.TraductionUK];

        affichage.Menu();
        string choix = Console.ReadLine();

        if (choix == "1")
        {
            affichage.Correction();
            string texte = Console.ReadLine();

            Console.WriteLine($"[ASSISTANT]: {service.getData(service.getPrompt(Correction, texte))}");
        }

        else if (choix == "2")
        {
            affichage.US_UK();
            string choixUsUk = Console.ReadLine();

            affichage.Traduction(choixUsUk);
            string texte = Console.ReadLine();

            Console.WriteLine($"[ASSISTANT]: {service.getData(service.getPrompt((choixUsUk == "1" ? TraductionUS : TraductionUK), texte))}");
        }
    }
}

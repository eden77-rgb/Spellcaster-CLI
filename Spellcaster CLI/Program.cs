using dotenv.net;

class Program 
{
    private const string PATH_ENV = ".env";

    public static void Main(string[] args)
    {
        DotEnv.Load(options: new DotEnvOptions(envFilePaths: new[] { PATH_ENV }));
        string apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
        
        UserInterfaces affichage = new UserInterfaces();

        affichage.Menu();
        string choix = Console.ReadLine();

        affichage.Correction();
        var texte = Console.ReadLine();

        OpenAIService service = new OpenAIService(apiKey);
        Console.WriteLine($"[ASSISTANT]: {service.getData(service.getPrompt(texte))}");
    }
}

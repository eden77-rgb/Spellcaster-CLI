using dotenv.net;
using OpenAI.Chat;

class Program 
{
    private const string PATH_ENV = ".env";
    
    public static void Main(string[] args)
    {
        DotEnv.Load(options: new DotEnvOptions(envFilePaths: new[] { PATH_ENV }));
        string apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");

        OpenAIService service = new OpenAIService(apiKey);        
        Console.WriteLine($"[ASSISTANT]: {service.getData("Say : Hello World")}");
    }
}

using dotenv.net;

class Program 
{
    private const string PATH_ENV = ".env";
    public static void Main(string[] args)
    {
        DotEnv.Load(options: new DotEnvOptions(envFilePaths: new[] { PATH_ENV }));

        var apiKey = Environment.GetEnvironmentVariable("API");

        Console.WriteLine(apiKey);
    }
} 

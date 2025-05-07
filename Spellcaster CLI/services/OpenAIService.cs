using OpenAI.Chat;

public class OpenAIService
{
    private readonly string apiKey;

    public OpenAIService(string apiKey)
    {
        this.apiKey = apiKey;   
    }

    public string getPrompt(string texte)
    {
        return $"Corrige les fautes d'orthographe et de grammaire du texte suivant : {texte}";
    }

    public string getData(string prompt)
    {
        ChatClient client = new(
            model: "gpt-4o-mini",
            apiKey: this.apiKey
        );

        ChatCompletion completion = client.CompleteChat(prompt);
        return completion.Content[0].Text;
    }
}

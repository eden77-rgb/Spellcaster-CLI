using System.Text.Json;

public class NewsAPIService
{
    private readonly string apiKey;
    private static HttpClient client = new HttpClient();

    public NewsAPIService(string apiKey)
    {
        this.apiKey = apiKey;
    }

    public async Task<string> getData(string categorie)
    {
        string URL = $"https://newsapi.org/v2/top-headlines?country=us&apiKey={this.apiKey}&category={categorie}&pageSize=5";
        string data = "";

        var reponse = await client.GetAsync(URL);

        if (reponse.IsSuccessStatusCode)
        {
            data = await reponse.Content.ReadAsStringAsync();
        }

        return data;
    }

    public JsonDocument getJson(string categorie)
    {
        string json = getData(categorie).GetAwaiter().GetResult();

        if (string.IsNullOrWhiteSpace(json))
        {
            Console.WriteLine("Réponse vide");
            return null;
        }

        JsonDocument document = JsonDocument.Parse(json);

        return document;
    }

    public string getTitre(string categorie, int id)
    {
        return getJson(categorie).RootElement.GetProperty("articles")[id].GetProperty("title").GetString();
    }

    public string getDescription(string categorie, int id)
    {
        return getJson(categorie).RootElement.GetProperty("articles")[id].GetProperty("content").GetString();
    }
}
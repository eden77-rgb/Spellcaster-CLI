using System.Text.Json;

public class NewsAPIService
{
    private readonly string apiKey;
    private static HttpClient client = new HttpClient();

    public NewsAPIService(string apiKey)
    {
        this.apiKey = apiKey;
    }

    static NewsAPIService()
    {
        client.DefaultRequestHeaders.Add("User-Agent", "CSharpApp");
    }

    public async Task<string> getData(string categorie)
    {
        string URL = $"https://newsapi.org/v2/top-headlines?country=us&apiKey={this.apiKey}&category={categorie}&pageSize=10";
        string data = "";

        var reponse = await client.GetAsync(URL);

        if (reponse.IsSuccessStatusCode)
        {
            data = await reponse.Content.ReadAsStringAsync();
        }

        else
        {
            Console.WriteLine($"[ERREUR] Code HTTP : {(int)reponse.StatusCode} - {reponse.ReasonPhrase}");
        }

        return data;
    }

    public async Task<JsonDocument> getJson(string categorie)
    {
        string json = await getData(categorie);

        if (string.IsNullOrWhiteSpace(json))
        {
            Console.WriteLine("Réponse vide");
            return null;
        }

        JsonDocument document = JsonDocument.Parse(json);

        return document;
    }

    public async Task<string> getTitre(string categorie, int id)
    {
        return (await getJson(categorie)).RootElement.GetProperty("articles")[id].GetProperty("title").GetString();
    }

    public async Task<string> getDescription(string categorie, int id)
    {
        return (await getJson(categorie)).RootElement.GetProperty("articles")[id].GetProperty("content").GetString();
    }

    public async Task<string> getImage(string categorie, int id)
    {
        return (await getJson(categorie)).RootElement.GetProperty("articles")[id].GetProperty("urlToImage").GetString();
    }

    public async Task<string> getUrl(string categorie, int id)
    {
        return (await getJson(categorie)).RootElement.GetProperty("articles")[id].GetProperty("url").GetString();
    }
}
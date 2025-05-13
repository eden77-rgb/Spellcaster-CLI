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

        try
        {
            var reponse = await client.GetAsync(URL);

            if (reponse.IsSuccessStatusCode)
            {
                data = await reponse.Content.ReadAsStringAsync();
            }

            else
            {
                Console.WriteLine($"[ERREUR]: Code HTTP : {(int)reponse.StatusCode} - {reponse.ReasonPhrase}");
            }
        }

        catch (HttpRequestException e)
        {
            Console.WriteLine($"[ERREUR]: Problème réseau - {e.Message}");
        }

        catch (Exception e)
        {
            Console.WriteLine($"[ERREUR]: Une erreur inattendue s'est produite - {e.Message}");
        }

        return data;
    }

    public async Task<JsonDocument> getJson(string categorie)
    {
        string json = await getData(categorie);

        if (string.IsNullOrWhiteSpace(json))
        {
            Console.WriteLine("[ERREUR]: Réponse vide ou null");
            return null;
        }

        try
        {
            JsonDocument document = JsonDocument.Parse(json);

            return document;
        }

        catch (JsonException e)
        {
            Console.WriteLine($"[ERREUR]: JSON invalide - {e.Message}");
            return null;
        }
    }

    public async Task<string> getTitre(string categorie, int id)
    {
        var json = await getJson(categorie);

        if (json == null)
        {
            return "Titre indisponible";
        }

        try
        {
            var documentArticles = json.RootElement.GetProperty("articles");

            if (id >= documentArticles.GetArrayLength())
            {
                Console.WriteLine($"[ERREUR]: Index {id} hors limites pour la catégorie : {categorie}.");
                return "Titre indisponible";
            }

            foreach (var propriete in documentArticles[id].EnumerateObject())
            {
                if (propriete.Name == "title")
                {
                    string titre = propriete.Value.GetString();
                    return string.IsNullOrEmpty(titre) ? "Titre indisponible" : titre;
                }
            }

            Console.WriteLine("[AVERTISSEMENT]: Le champ : title est absent.");
            return "Titre indisponible";
        }

        catch (Exception e)
        {
            Console.WriteLine($"[ERREUR]: Impossible de récupérer le titre - {e.Message}");
            return "Titre indisponible";
        }
    }

    public async Task<string> getDescription(string categorie, int id)
    {
        var json = await getJson(categorie);

        if (json == null)
        {
            return "Description indisponible";
        }

        try
        {
            var documentArticles = json.RootElement.GetProperty("articles");

            if (id >= documentArticles.GetArrayLength())
            {
                Console.WriteLine($"[ERREUR]: Index {id} hors limites pour la catégorie : {categorie}.");
                return "Description indisponible";
            }

            foreach (var propriete in documentArticles[id].EnumerateObject())
            {
                if (propriete.Name == "description")
                {
                    string description = propriete.Value.GetString();
                    return string.IsNullOrEmpty(description) ? "Description indisponible" : description;
                }
            }
            
            Console.WriteLine("[AVERTISSEMENT]: Le champ : description est absent.");
            return "Description indisponible";
        }

        catch (Exception e)
        {
            Console.WriteLine($"[ERREUR]: Impossible de récupérer la description - {e.Message}");
            return "Description indisponible";
        }
    }

    public async Task<string> getImage(string categorie, int id)
    {
        var json = await getJson(categorie);

        if (json == null)
        {
            return "Image indisponible";
        }

        try
        {
            var documentArticles = json.RootElement.GetProperty("articles");

            if (id >= documentArticles.GetArrayLength())
            {
                Console.WriteLine($"[ERREUR]: Index {id} hors limites pour la catégorie : {categorie}.");
                return "Image indisponible";
            }

            foreach (var propriete in documentArticles[id].EnumerateObject())
            {
                if (propriete.Name == "urlToImage")
                {
                    string image = propriete.Value.GetString();
                    return string.IsNullOrEmpty(image) ? "Image indisponible" : image;
                }
            }

            Console.WriteLine("[AVERTISSEMENT]: Le champ : urlToImage est absent.");
            return "Image indisponible";
        }

        catch (Exception e)
        {
            Console.WriteLine($"[ERREUR]: Impossible de récupérer l'url de l'image - {e.Message}");
            return "Image indisponible";
        }
    }

    public async Task<string> getUrl(string categorie, int id)
    {
        var json = await getJson(categorie);

        if (json == null)
        {
            return "Url indisponible";
        }

        try
        {
            var documentArticles = json.RootElement.GetProperty("articles");

            if (id >= documentArticles.GetArrayLength())
            {
                Console.WriteLine($"[ERREUR]: Index {id} hors limites pour la catégorie : {categorie}.");
                return "Url indisponible";
            }

            foreach (var propriete in documentArticles[id].EnumerateObject())
            {
                if (propriete.Name == "url")
                {
                    string url = propriete.Value.GetString();
                    return string.IsNullOrEmpty(url) ? "Url indisponible" : url;
                }
            }
            
            Console.WriteLine("[AVERTISSEMENT]: Le champ : url est absent.");
            return "Url indisponible";
        }

        catch (Exception e)
        {
            Console.WriteLine($"[ERREUR]: Impossible de récupérer l'url - {e.Message}");
            return "Url indisponible";
        }
    }
}
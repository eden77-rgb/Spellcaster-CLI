using System.Threading.Tasks;

class HtmlGenerator
{
    public async Task Generate(string fileName, NewsAPIService newsAPI)
    {
        string html = $@"
        <!DOCTYPE html>
        <html lang='en'>
        <head>
            <meta charset='UTF-8'>
            <meta name='viewport' content='width=device-width, initial-scale=1.0'>
            <title>{fileName}</title>
            <link rel='stylesheet' href='../style/style.css'>
        </head>
        <body>
            <div class='container'>
        ";

        for (int i = 0; i < 6; i++)
        {
            var t1 = await newsAPI.getTitre(fileName, i);
            var i1 = await newsAPI.getImage(fileName, i);
            var d1 = await newsAPI.getDescription(fileName, i);
            var l1 = await newsAPI.getUrl(fileName, i);

            html += $@"
                <div class='card'>
                    <h2>{t1}</h2>
                    <img src='{i1}' alt=''>
                    <p>{d1}</p>
                    <a href='{l1}'>{l1}</a>
                </div>
            ";
        }
        
        html += @"
            </div>
        </body>
        </html>
        ";

        File.WriteAllText($"output/{fileName}.html", html);
    }
}
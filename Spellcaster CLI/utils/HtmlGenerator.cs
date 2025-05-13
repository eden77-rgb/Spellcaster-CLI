using System.Threading.Tasks;

class HtmlGenerator
{
    public async Task Generate(string fileName, NewsAPIService newsAPI)
    {
        var t1 = await newsAPI.getTitre(fileName, 0);
        var i1 = await newsAPI.getImage(fileName, 0);
        var d1 = await newsAPI.getDescription(fileName, 0);
        var l1 = await newsAPI.getUrl(fileName, 0);

        var t2 = await newsAPI.getTitre(fileName, 1);
        var i2 = await newsAPI.getImage(fileName, 1);
        var d2 = await newsAPI.getDescription(fileName, 1);
        var l2 = await newsAPI.getUrl(fileName, 1);

        var t3 = await newsAPI.getTitre(fileName, 2);
        var i3 = await newsAPI.getImage(fileName, 2);
        var d3 = await newsAPI.getDescription(fileName, 2);
        var l3 = await newsAPI.getUrl(fileName, 2);

        var t4 = await newsAPI.getTitre(fileName, 3);
        var i4 = await newsAPI.getImage(fileName, 3);
        var d4 = await newsAPI.getDescription(fileName, 3);
        var l4 = await newsAPI.getUrl(fileName, 3);

        var t5 = await newsAPI.getTitre(fileName, 4);
        var i5 = await newsAPI.getImage(fileName, 4);
        var d5 = await newsAPI.getDescription(fileName, 4);
        var l5 = await newsAPI.getUrl(fileName, 4);

        var t6 = await newsAPI.getTitre(fileName, 5);
        var i6 = await newsAPI.getImage(fileName, 5);
        var d6 = await newsAPI.getDescription(fileName, 5);
        var l6 = await newsAPI.getUrl(fileName, 5);

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
                <div class='card'>
                    <h2>{t1}</h2>
                    <img src='{i1}' alt=''>
                    <p>{d1}</p>
                    <a href='{l1}'>{l1}</a>
                </div>
                
                <div class='card'>
                    <h2>{t2}</h2>
                    <img src='{i2}' alt=''>
                    <p>{d2}</p>
                    <a href='{l2}'>{l2}</a>
                </div>

                <div class='card'>
                    <h2>{t3}</h2>
                    <img src='{i3}' alt=''>
                    <p>{d3}</p>
                    <a href='{l3}'>{l3}</a>
                </div>

                <div class='card'>
                    <h2>{t4}</h2>
                    <img src='{i4}' alt=''>
                    <p>{d4}</p>
                    <a href='{l4}'>{l4}</a>
                </div>

                <div class='card'>
                    <h2>{t5}</h2>
                    <img src='{i5}' alt=''>
                    <p>{d5}</p>
                    <a href='{l5}'>{l5}</a>
                </div>

                <div class='card'>
                    <h2>{t6}</h2>
                    <img src='{i6}' alt=''>
                    <p>{d6}</p>
                    <a href='{l6}'>{l6}</a>
                </div>
            </div>
        </body>
        </html>
        ";

        File.WriteAllText($"output/{fileName}.html", html);
    }
}
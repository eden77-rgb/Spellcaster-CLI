class HtmlGenerator
{
    public void Generate(string fileName, NewsAPIService newsAPI)
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
                <div class='card'>
                    <h2>{newsAPI.getTitre(fileName, 0)}</h2>
                    <img src='{newsAPI.getImage(fileName, 0)}' alt=''>
                    <p>{newsAPI.getDescription(fileName, 0)}</p>
                    <a href='{newsAPI.getUrl(fileName, 0)}'>{newsAPI.getUrl(fileName, 0)}</a>
                </div>
                
                <div class='card'>
                    <h2>{newsAPI.getTitre(fileName, 1)}</h2>
                    <img src='{newsAPI.getImage(fileName, 1)}' alt=''>
                    <p>{newsAPI.getDescription(fileName, 1)}</p>
                    <a href='{newsAPI.getUrl(fileName, 1)}'>{newsAPI.getUrl(fileName, 1)}</a>
                </div>

                <div class='card'>
                    <h2>{newsAPI.getTitre(fileName, 2)}</h2>
                    <img src='{newsAPI.getImage(fileName, 2)}' alt=''>
                    <p>{newsAPI.getDescription(fileName, 2)}</p>
                    <a href='{newsAPI.getUrl(fileName, 2)}'>{newsAPI.getUrl(fileName, 2)}</a>
                </div>

                <div class='card'>
                    <h2>{newsAPI.getTitre(fileName, 3)}</h2>
                    <img src='{newsAPI.getImage(fileName, 3)}' alt=''>
                    <p>{newsAPI.getDescription(fileName, 3)}</p>
                    <a href='{newsAPI.getUrl(fileName, 3)}'>{newsAPI.getUrl(fileName, 3)}</a>
                </div>

                <div class='card'>
                    <h2>{newsAPI.getTitre(fileName, 4)}</h2>
                    <img src='{newsAPI.getImage(fileName, 4)}' alt=''>
                    <p>{newsAPI.getDescription(fileName, 4)}</p>
                    <a href='{newsAPI.getUrl(fileName, 4)}'>{newsAPI.getUrl(fileName, 4)}</a>
                </div>
                
                <div class='card'>
                    <h2>{newsAPI.getTitre(fileName, 5)}</h2>
                    <img src='{newsAPI.getImage(fileName, 5)}' alt=''>
                    <p>{newsAPI.getDescription(fileName, 5)}</p>
                    <a href='{newsAPI.getUrl(fileName, 5)}'>{newsAPI.getUrl(fileName, 5)}</a>
                </div>
            </div>
        </body>
        </html>
        ";

        File.WriteAllText($"output/{fileName}.html", html);
    }
}
using System.Net.Http.Headers;
using Alura.Adopet.Console.Comandos;

// na linha abaixo cria-se uma instância de HttpClient para consumir API Adopet.
HttpClient client = ConfiguraHttpClient("http://localhost:5057");
Console.ForegroundColor = ConsoleColor.Green;
try
{
    string comando = args[0].Trim();
    switch (comando)
    {
        case "import":
            var import = new Import();
            await import.ExecutarAsync(args);
            break;
        case "help":
            var help = new Help();
            await help.ExecutarAsync(args);
            break;
        case "show":
            var show = new Show();
            await show.ExecutarAsync(args);
            break;
        case "list":
            var list = new List();
            await list.ExecutarAsync(args);
            break;
        default:
            Console.WriteLine("Comando inválido!");
            break;
    }
}
catch (Exception ex)
{
    // mostra a exceção em vermelho
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Aconteceu um exceção: {ex.Message}");
}
finally
{
    Console.ForegroundColor = ConsoleColor.White;
}

HttpClient ConfiguraHttpClient(string url)
{
    HttpClient _client = new HttpClient();
    _client.DefaultRequestHeaders.Accept.Clear();
    _client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));
    _client.BaseAddress = new Uri(url);
    return _client;
}
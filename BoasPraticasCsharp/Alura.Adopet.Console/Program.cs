using System.Net.Http.Headers;
using System.Net.Http.Json;
using Alura.Adopet.Console;

// cria instância de HttpClient para consumir API Adopet
HttpClient client = ConfiguraHttpClient("http://localhost:5057");
Console.ForegroundColor = ConsoleColor.Green;
try
{
    // args[0] é o comando a ser executado pelo programa
    switch (args[0].Trim())
    {
        case "import":
            List<Pet> listaDePet = new List<Pet>();

            // args[1] é o caminho do arquivo a ser importado
            using (StreamReader sr = new StreamReader(args[1]))
            {
                while (!sr.EndOfStream)
                {
                    // separa linha usando ponto e vírgula
                    string[] propriedades = sr.ReadLine().Split(';');
                    // cria objeto Pet a partir da separação
                    Pet pet = new Pet(Guid.Parse(propriedades[0]),
                      propriedades[1],
                      TipoPet.Cachorro
                     );

                    Console.WriteLine(pet);
                    listaDePet.Add(pet);
                }
            }
            foreach (var pet in listaDePet)
            {
                try
                {
                    var resposta = await CreatePetAsync(pet);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine("Importação concluída!");
            break;
        case "help":
            Console.WriteLine("Lista de comandos.");
            // se não passou mais nenhum argumento mostra help de todos os comandos
            if (args.Length == 1)
            {
                Console.WriteLine("adopet help <parametro> ous simplemente adopet help  " +
                     "comando que exibe informações de ajuda dos comandos.");
                Console.WriteLine("Adopet (1.0) - Aplicativo de linha de comando (CLI).");
                Console.WriteLine("Realiza a importação em lote de um arquivos de pets.");
                Console.WriteLine("Comando possíveis: ");
                Console.WriteLine($" adopet import <arquivo> comando que realiza a importação do arquivo de pets.");
                Console.WriteLine($" adopet show   <arquivo> comando que exibe no terminal o conteúdo do arquivo importado." + "\n\n\n\n");
                Console.WriteLine("Execute 'adopet.exe help [comando]' para obter mais informações sobre um comando." + "\n\n\n");
            }
            // exibe o help daquele comando específico
            else if (args.Length == 2)
            {
                if (args[1].Equals("import"))
                {
                    Console.WriteLine(" adopet import <arquivo> " +
                        "comando que realiza a importação do arquivo de pets.");
                }
                if (args[1].Equals("show"))
                {
                    Console.WriteLine(" adopet show <arquivo>  comando que " +
                        "exibe no terminal o conteúdo do arquivo importado.");
                }
            }
            break;
        case "show":
            // args[1] é o caminho do arquivo a ser exibido
            using (StreamReader sr = new StreamReader(args[1]))
            {
                Console.WriteLine("----- Serão importados os dados abaixo -----");
                while (!sr.EndOfStream)
                {
                    // separa linha usando ponto e vírgula
                    string[] propriedades = sr.ReadLine().Split(';');
                    // cria objeto Pet a partir da separação
                    Pet pet = new Pet(Guid.Parse(propriedades[0]),
                    propriedades[1],
                    TipoPet.Cachorro
                    );
                    Console.WriteLine(pet);
                }
            }
            break;
        case "list":
            var pets = await ListPetsAsync();
            foreach(var pet in pets)
            {
                Console.WriteLine(pet);
            }
            break;
        default:
            // exibe mensagem de comando inválido
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

Task<HttpResponseMessage> CreatePetAsync(Pet pet)
{
    HttpResponseMessage? response = null;
    using (response = new HttpResponseMessage())
    {
        return client.PostAsJsonAsync("pet/add", pet);
    }
}

async Task<IEnumerable<Pet>?> ListPetsAsync()
{
    HttpResponseMessage response = await client.GetAsync("pet/list");
    return await response.Content.ReadFromJsonAsync<IEnumerable<Pet>>();
}
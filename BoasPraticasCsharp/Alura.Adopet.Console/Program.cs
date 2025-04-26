using Alura.Adopet.Console.Comandos;

ComandosDoSistema comandos = new();

Console.ForegroundColor = ConsoleColor.Green;
try
{
    string comando = args[0].Trim();
    IComando? cmd = comandos[comando];
    if (cmd is not null) await cmd.ExecutarAsync(args);
    else Console.WriteLine("Comando inválido!");
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Aconteceu um exceção: {ex.Message}");
}
finally
{
    Console.ForegroundColor = ConsoleColor.White;
}
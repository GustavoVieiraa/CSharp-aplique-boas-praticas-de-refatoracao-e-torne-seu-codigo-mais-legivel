

namespace Alura.Adopet.Console.Comandos
{
    internal interface IComando
    {
        Task ExecutarAsync(string[] args);
    }
}

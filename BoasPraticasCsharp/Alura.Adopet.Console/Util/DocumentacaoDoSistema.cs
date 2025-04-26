using Alura.Adopet.Console.Comandos;
using System.Reflection;


namespace Alura.Adopet.Console.Util
{
    public class DocumentacaoDoSistema
    {
        public static Dictionary<string, DocComando> ToDictionary(Assembly assemblyComOTipoDocComando)
        {
            return assemblyComOTipoDocComando.GetTypes()
             .Where(t => t.GetCustomAttributes<DocComando>().Any())
             .Select(t => t.GetCustomAttribute<DocComando>()!)
             .ToDictionary(d => d.Instrucao);
        }
    }
}
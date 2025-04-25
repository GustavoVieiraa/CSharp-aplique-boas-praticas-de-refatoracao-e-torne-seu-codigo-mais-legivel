using System.Reflection;

namespace Alura.Adopet.Console
{
    [DocComando(instrucao: "help",
     documentacao: "adopet help comando que exibe informações da ajuda.")]
    internal class Help
    {
        private Dictionary<string, DocComando> docs;
        public Help()
        {
            docs = Assembly.GetExecutingAssembly().GetTypes()
                    .Where(t => t.GetCustomAttributes<DocComando>().Any())
                    .Select(t => t.GetCustomAttributes<DocComando>().First())
                    .ToDictionary(d => d.Instrucao);
        }

        public void ExibeDocumentacao(string[] parametros)
        {
            // se não passou mais nenhum argumento mostra help de todos os comandos
            if (parametros.Length == 1)
            {
                System.Console.WriteLine($"Adopet (1.0) - Aplicativo de linha de comando (CLI).");
                System.Console.WriteLine($"Realiza a importação em lote de um arquivos de pets.");
                System.Console.WriteLine($"Comando possíveis: ");
                foreach (var doc in docs.Values)
                {
                    System.Console.WriteLine(doc.Documentacao);
                }


            }
            // exibe o help daquele comando específico
            else if (parametros.Length == 2)
            {
                string comandoASerExibido = parametros[1];
                if (docs.ContainsKey(comandoASerExibido))
                {
                    var comando = docs[comandoASerExibido];
                    System.Console.WriteLine(comando.Documentacao);
                }
                //if (comandoASerExibido.Equals("import"))
                //{
                //    System.Console.WriteLine($"adopet import <arquivo> " +
                //        "comando que realiza a importação do arquivo de pets.");
                //}
                //if (comandoASerExibido.Equals("show"))
                //{
                //    System.Console.WriteLine($"adopet show <arquivo>  comando que " +
                //        "exibe no terminal o conteúdo do arquivo importado.");
                //}
                //if (comandoASerExibido.Equals("list"))
                //{
                //    System.Console.WriteLine($"adopet list comando que exibe no terminal o conteúdo cadastrado na base de dados da AdoPet.");
                //}
            }
        }
    }
}
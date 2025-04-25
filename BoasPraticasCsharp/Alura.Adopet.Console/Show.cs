namespace Alura.Adopet.Console
{
    [DocComando(instrucao: "show",
    documentacao: "adopet show <ARQUIVO> comando que exibe no terminal o conteúdo do arquivo importado.")]
    internal class Show
    {
        public void ExibeConteudoArquivo(string caminhoDoArquivoASerExibido)
        {
            LeitorDeArquivo leitor = new LeitorDeArquivo();
            var listaDepets = leitor.RealizaLeitura(caminhoDoArquivoASerExibido);
            foreach (var pet in listaDepets)
            {
                System.Console.WriteLine(pet);
            }


        }
    }
}
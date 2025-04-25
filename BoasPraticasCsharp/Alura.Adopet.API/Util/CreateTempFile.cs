namespace Alura.Adopet.API.Util
{
    internal static class CreateTempFile
    {
        public static string CreateTempfilePath()
        {
            var filename = $@"{DateTime.Now.Ticks}.tmp";

            var directoryPath = Path.Combine("Files", "Uploads");

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            return Path.Combine(directoryPath, filename);
        }
    }
}

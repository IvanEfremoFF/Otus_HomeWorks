namespace TelegramBot
{
    internal class Secrets
    {
        public string? TGBotToken { get; private set;}

        public Secrets()
        {
            var fileSecrets = new StreamReader("secrets.ini");
            var token = String.Empty;

            try
            {
                token = fileSecrets?.ReadLine() as string;
            }
            catch (Exception)
            {
                throw;
            }
            fileSecrets.Close();
            TGBotToken = token;
        }
    }
}

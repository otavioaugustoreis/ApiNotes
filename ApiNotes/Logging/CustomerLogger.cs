using ApiNotes.Logging;
using System.Runtime.CompilerServices;

namespace ApiNotes.Logging
{
    public class CustomerLogger : ILogger
    {
        readonly string loggerName;

        readonly CustomLoggerProviderConfiguration loggerConfig;

        public CustomerLogger(string name, CustomLoggerProviderConfiguration loggerConfig)
        {
            this.loggerConfig = loggerConfig;
            //Recebe uma categoria
            this.loggerName = name;
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }
        //Verifica se o nivel de Log desejado está habilitado
        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel == loggerConfig.LogLevel;
        }
        //Método chamado para registrar uma mensagem de log
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
           //Formatando uma mensagem
            string message = $"{logLevel.ToString()}: {eventId.Id} - {formatter(state, exception)}";

            EscreverTextoNoArquivo(message);
        }
        
        private void EscreverTextoNoArquivo(string mensagem)
        {
            //Caminho para salvar
            string caminhoArquivoLog = @"C:\Project_Spring\logging\logging_notes_application.txt";


            using (StreamWriter streamWriter = new StreamWriter(caminhoArquivoLog, true))
            {
                try
                {
                    streamWriter.WriteLine(mensagem);
                    streamWriter.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}


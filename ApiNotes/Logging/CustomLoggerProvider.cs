using ApiNotes.Logging;
using System.Collections.Concurrent;

namespace ApiNotes.Logging
{
    public class CustomLoggerProvider : ILoggerProvider
    {
        readonly CustomLoggerProviderConfiguration loggerConfig;
        //Dicionario de Loggers
        readonly ConcurrentDictionary<string, CustomerLogger> loggers = new ConcurrentDictionary<string, CustomerLogger>();
        //Definindo a configuração para todos os loggers criados deste provedor
        public CustomLoggerProvider(CustomLoggerProviderConfiguration loggerConfig)
        {
            this.loggerConfig = loggerConfig;
        }
        //Criando um Logger para uma categoria especifica(categoryName)
        public ILogger CreateLogger(string categoryName)
        {
            //retorna um Logger existente do dicionário loggers, ou se não existir ele é descartado
            return loggers.GetOrAdd(categoryName, name => new CustomerLogger(name, loggerConfig));
        }
        //Descartando o objeto caso não seja retornado
        public void Dispose()
        {
            loggers.Clear();
        }
    }
}

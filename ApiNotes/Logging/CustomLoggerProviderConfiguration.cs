namespace ApiNotes.Logging
{
    public class CustomLoggerProviderConfiguration
    {
        //Define o nível minimo de lo a ser registrado, com o padrão LogLevel.Warning
        
        public LogLevel LogLevel { get; set; } = LogLevel.Warning;
        //Define o ID do evnto de log, com o padrão sendo zero
        public int EventId { get; set; } = 0;
    }
}

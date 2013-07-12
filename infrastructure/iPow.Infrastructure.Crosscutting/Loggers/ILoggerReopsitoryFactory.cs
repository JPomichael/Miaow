namespace iPow.Infrastructure.Crosscutting.Loggers
{
    public interface ILoggerReopsitoryFactory
    {
        ILoggerReopsitory CreateLogger();
    }
}

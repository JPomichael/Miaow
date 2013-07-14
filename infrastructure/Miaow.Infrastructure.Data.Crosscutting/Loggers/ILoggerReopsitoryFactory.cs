namespace Miaow.Infrastructure.Crosscutting.Loggers
{
    public interface ILoggerReopsitoryFactory
    {
        ILoggerReopsitory CreateLogger();
    }
}

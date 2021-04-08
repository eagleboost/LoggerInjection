namespace LoggerInjectionApp.Logging
{
  using log4net;

  public class Log4NetLogger<T> : ILogger
  {
    private static readonly ILog InnerLogger = LogManager.GetLogger(typeof(T));
    
    public void Info(string msg)
    {
      InnerLogger.Info(msg);
    }
  }
}
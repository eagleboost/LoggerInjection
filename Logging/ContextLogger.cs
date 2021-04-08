namespace LoggerInjectionApp.Logging
{
  using System;

  public sealed class ContextLogger : ILogger
  {
    private readonly ILogger _logger;
    private readonly ILogContext _logContext;

    public ContextLogger(ILogContext logContext, ILogger logger)
    {
      _logContext = logContext ?? throw new ArgumentNullException(nameof(logContext));
      _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public void Info(string msg)
    {
      LogCore(msg);
    }
    
    private void LogCore(string msg)
    {
      _logger.Info($"{_logContext.Context} : {msg}");
    }
  }
}
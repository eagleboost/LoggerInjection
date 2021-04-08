namespace LoggerInjectionApp.Logging
{
  using System;
  using System.Collections.Concurrent;
  using System.Diagnostics;

  public static class LoggerManager
  {
    private static readonly ConcurrentDictionary<Type, ILogger> Loggers = new ConcurrentDictionary<Type, ILogger>();
    
    public static ILogger GetLogger(Type type)
    {
      return Loggers.GetOrAdd(type, CreateLogger);
    }

    private static ILogger CreateLogger(Type type)
    {
      if (Debugger.IsAttached)
      {
        return (ILogger) Activator.CreateInstance(typeof(TraceLogger<>).MakeGenericType(type));
      }
      
      return (ILogger) Activator.CreateInstance(typeof(Log4NetLogger<>).MakeGenericType(type));
    }
  }
}
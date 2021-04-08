namespace LoggerInjectionApp.Logging
{
  using System.Diagnostics;

  public class TraceLogger<T> : ILogger
  {
    private static readonly string TypeName = typeof(T).FullName;
    
    public void Info(string msg)
    {
      LogCore(msg);
    }

    private static void LogCore(string msg)
    {
      Trace.WriteLine($"{TypeName} : {msg}");
    }
  }
}
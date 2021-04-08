namespace LoggerInjectionApp
{
  using global::Unity;
  using LoggerInjectionApp.Logging;

  public class ViewModel : ILogContext
  {
    [Dependency]
    public ILogger Logger { get; set; }
  
    public object Context { get; set; }

    public void TestLog(string msg)
    {
      Logger.Info(msg);
    }
  }
}
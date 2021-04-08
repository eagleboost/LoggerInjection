namespace LoggerInjectionApp
{
  using global::Unity;
  using LoggerInjectionApp.Unity;

  internal class Program
  {
    public static void Main(string[] args)
    {
      var container = new UnityContainer();
      container.AddNewExtension<LoggerExtension>();
      var viewModel = container.Resolve<ViewModel>();
      viewModel.Context = "ViewModel 1";
      viewModel.TestLog("This is a log");
    }
  }
}
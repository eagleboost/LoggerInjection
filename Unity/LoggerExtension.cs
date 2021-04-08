namespace LoggerInjectionApp.Unity
{
  using global::Unity.Builder;
  using global::Unity.Extension;

  public sealed class LoggerExtension : UnityContainerExtension
  {
    protected override void Initialize()
    {
      Context.Strategies.Add(new LoggerStrategy(), UnityBuildStage.PreCreation);
    }
  }
}
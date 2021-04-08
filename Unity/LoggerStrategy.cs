namespace LoggerInjectionApp.Unity
{
  using System;
  using System.Runtime.CompilerServices;
  using global::Unity.Builder;
  using global::Unity.Strategies;
  using LoggerInjectionApp.Logging;

  public class LoggerStrategy : BuilderStrategy
  {
    public override void PreBuildUp(ref BuilderContext context)
    {
      base.PreBuildUp(ref context);

      if (typeof(ILogger).IsAssignableFrom(context.Type))
      {
        context.Existing = CreateLogger(ref context);
        context.BuildComplete = true;
      }
    }

    private static ILogger CreateLogger(ref BuilderContext context)
    {
      var result = LoggerManager.GetLogger(context.DeclaringType);
      ////Try creating ContextLogger if the declaring type implements ILogContext
      if (typeof(ILogContext).IsAssignableFrom(context.DeclaringType))
      {
        if (context.Existing == null && context.Parent != IntPtr.Zero)
        {
          unsafe
          {
            var pContext = Unsafe.AsRef<BuilderContext>(context.Parent.ToPointer());
            ////pContext.Existing is null when ILogger is being injected to the ctor
            if (pContext.Existing is ILogContext logContext)
            {
              ////If ILogger is being injected to a property, we create a ContextLogger to wrap the real logger
              result = new ContextLogger(logContext, result);
            }
          }
        }
      }

      return result;
    }
  }
}
using BuilderPatterns.Builder.Implementations;

namespace DesignPatternConsole.GetRobotos.Implementations
{
	internal class SingletonGetRobotoMethod : ISingletonGetRobotoMethod
	{
		public DesignPatterns.Implementations.Roboto GetRoboto()
		{
			return AlphaRobotoSingleton.Instance();
		}
	}
}
using BuilderPatterns.Implementations;

namespace DesignPatternConsole.Creational.Implementations
{
	internal class SingletonGetRobotoMethod : ISingletonGetRobotoMethod
	{
		public DesignPatterns.Implementations.Roboto GetRoboto()
		{
			return AlphaRobotoSingleton.Instance();
		}
	}
}
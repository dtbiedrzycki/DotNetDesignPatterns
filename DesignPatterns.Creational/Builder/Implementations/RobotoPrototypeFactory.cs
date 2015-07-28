using DesignPatterns.Implementations;

namespace BuilderPatterns.Builder.Implementations
{
	public class RobotoPrototypeFactory : IRobotoFactory
	{
		private readonly Roboto _rollingRoboto;
		private readonly Roboto _humanoidRoboto;

		public RobotoPrototypeFactory(Roboto rollingRoboto, Roboto humanoidRoboto)
		{
			_rollingRoboto = rollingRoboto;
			_humanoidRoboto = humanoidRoboto;
		}

		public Roboto CreateRollingRoboto()
		{
			return _rollingRoboto.Clone() as Roboto;
		}

		public Roboto CreateHumanoidRoboto()
		{
			return _humanoidRoboto.Clone() as Roboto;
		}
	}
}

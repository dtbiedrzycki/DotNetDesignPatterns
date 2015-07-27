using DesignPatterns.Implementations;

namespace BuilderPatterns.Builder
{
	public interface IRobotoFactory
	{
		Roboto CreateRollingRoboto();
		Roboto CreateHumanoidRoboto();
	}
}

using DesignPatterns.Implementations;

namespace BuilderPatterns
{
	/// <summary>
	/// A creation pattern that creates instances of other classes
	/// </summary>
	public interface IRobotoFactory
	{
		Roboto CreateRollingRoboto();
		Roboto CreateHumanoidRoboto();
	}
}
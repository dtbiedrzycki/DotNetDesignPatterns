using DesignPatterns.Implementations;

namespace BuilderPatterns.AbstractFactory
{
	/// <summary>
	/// A creation pattern that creates families of related objects without
	/// requiring the user to know the concrete classes
	/// </summary>
	public interface IRobotoFactory
	{
		Roboto CreateRollingRoboto();
		Roboto CreateHumanoidRoboto();
	}
}
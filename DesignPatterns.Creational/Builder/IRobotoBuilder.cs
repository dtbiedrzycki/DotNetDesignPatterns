using DesignPatterns.Implementations;

namespace BuilderPatterns.Builder
{
	/// <summary>
	/// A creational pattern that separates the object construction from its representation.
	/// Allows a user to user the same construction process to create different representations.
	/// </summary>
	public interface IRobotoBuilder
	{
		void CreateNewRoboto();
		void AddArm();
		void AddMobilitySystem();
		Roboto GetRoboto();
	}
}
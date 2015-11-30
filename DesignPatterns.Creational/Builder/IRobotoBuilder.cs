using DesignPatterns.Implementations;

namespace BuilderPatterns.Builder
{
	/// <summary>
	/// A creational pattern that separates the object construction from its representation
	/// </summary>
	public interface IRobotoBuilder
	{
		void CreateNewRoboto();
		void AddArm();
		void AddMobilitySystem();
		Roboto GetRoboto();
	}
}
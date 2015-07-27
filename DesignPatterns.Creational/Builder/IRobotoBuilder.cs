using DesignPatterns.Implementations;

namespace BuilderPatterns.Builder
{
	public interface IRobotoBuilder
	{
		void CreateNewRoboto();
		void AddArm();
		void AddMobilitySystem();
		Roboto GetRoboto();
	}
}
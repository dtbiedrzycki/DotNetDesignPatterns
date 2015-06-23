using DesignPatterns.Implementations;

namespace BuilderPatterns.Builder
{
	public interface IRobotoBuilder
	{
		void BuildNewRoboto();
		void BuildArm();
		void BuildMobilitySystem();
		Roboto GetRoboto();
	}
}
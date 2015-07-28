namespace DesignPatterns
{
	public interface IPowerSource
	{
		int CurrentCharge { get; }
		int Capacity { get; }
		bool ProvidePower(int watts);
		bool Charge(int watts);
	}
}
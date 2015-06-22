namespace DesignPatterns
{
	public interface IPowerSource
	{
		bool ProvidePower(int watts);
		bool Charge(int watts);
		int CurrentCharge { get; }
		int Capacity { get; }
	}
}
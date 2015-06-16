namespace DesignPatterns
{
	public interface IPowerSource
	{
		void ProvidePower(int watts);
		void Charge(int watts);
	}
}
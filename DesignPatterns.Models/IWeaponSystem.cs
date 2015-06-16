namespace DesignPatterns
{
	public interface IWeaponSystem
	{
		/// <summary>
		/// Activates the weapon
		/// </summary>
		/// <returns>The wattage required to fire the weapon</returns>
		int Activate();

		/// <summary>
		/// Returns the frequency of which the weapon can be activated (in seconds)
		/// </summary>
		double UsageFrequencyInSeconds { get; }
	}
}
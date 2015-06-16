namespace DesignPatterns
{
	public interface IMotor
	{
		/// <summary>
		/// Powers on the motor
		/// </summary>
		/// <returns>The wattage required to turn the motor on</returns>
		int PowerOn();

		/// <summary>
		/// Powers off the motor
		/// </summary>
		void PowerOff();

		/// <summary>
		/// Activates the motor (i.e. motor is used)
		/// </summary>
		/// <param name="powerPercentage">The perctange of power to apply (values between 0-1)</param>
		/// <returns>The wattage required to use the motor</returns>
		int Activate(double powerPercentage);

		/// <summary>
		/// Activates the motor in the reverse direction
		/// </summary>
		/// <param name="powerPercentage">The perctange of power to apply (values between 0-1)</param>
		/// <returns>The wattage required to use the motor</returns>
		int ActivateReverse(double powerPercentage);
	}
}
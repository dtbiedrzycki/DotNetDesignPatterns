namespace DesignPatterns
{
	public interface IMotor
	{
		/// <summary>
		/// Powers on the motor
		/// </summary>
		/// <returns>Returns <code>True</code> if the motor powers on, <code>False</code> otherwise</returns>
		bool PowerOn();

		/// <summary>
		/// Powers off the motor
		/// </summary>
		/// <returns>Returns <code>True</code> if the motor powers off, <code>False</code> otherwise</returns>
		bool PowerOff();

		/// <summary>
		/// Activates the motor (i.e. motor is used)
		/// </summary>
		/// <param name="powerPercentage">The perctange of power to apply (values between 0-1)</param>
		/// <returns>Returns <code>True</code> if the motor activates, <code>False</code> otherwise</returns>
		bool Activate(double powerPercentage);

		/// <summary>
		/// Activates the motor in the reverse direction
		/// </summary>
		/// <param name="powerPercentage">The perctange of power to apply (values between 0-1)</param>
		/// <returns>Returns <code>True</code> if the motor activates in reverse, <code>False</code> otherwise</returns>
		bool ActivateReverse(double powerPercentage);
	}
}
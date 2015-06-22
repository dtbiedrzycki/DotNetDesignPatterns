namespace DesignPatterns.Implementations
{
	public class SimpleMotor : IMotor
	{
		private readonly IPowerSource _powerSource;
		private bool _isOn = false;

		private const int POWER_ON_WATTS = 2;
		private const int ACTIVATE_WATTS = 10;

		public SimpleMotor(IPowerSource powerSource)
		{
			_powerSource = powerSource;
			_isOn = false;
		}

		public bool PowerOn()
		{
			if (!_isOn && _powerSource.ProvidePower(POWER_ON_WATTS))
			{
				_isOn = true;
			}

			return _isOn;
		}

		public bool PowerOff()
		{
			_isOn = false;

			return _isOn;
		}

		public bool Activate(double powerPercentage)
		{
			if (_isOn && powerPercentage > 0 && powerPercentage <= 1)
			{
				_powerSource.ProvidePower(ACTIVATE_WATTS);
				return true;
			}

			return false;
		}

		public bool ActivateReverse(double powerPercentage)
		{
			return Activate(powerPercentage);
		}
	}
}
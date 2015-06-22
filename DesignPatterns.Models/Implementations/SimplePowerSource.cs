namespace DesignPatterns.Implementations
{
	public class SimplePowerSource : IPowerSource
	{
		private const int MAX_CAPACITY = 100;
		private int _currentCharge = 0;

		public bool ProvidePower(int watts)
		{
			_currentCharge -= watts;

			if (_currentCharge <= 0)
			{
				_currentCharge = 0;
				return false;
			}

			return true;
		}

		public bool Charge(int watts)
		{
			if (watts <= 0)
			{
				return false;
			}

			_currentCharge += watts;
			if (_currentCharge > MAX_CAPACITY)
			{
				_currentCharge = MAX_CAPACITY;
			}

			return true;
		}

		public int CurrentCharge
		{
			get { return _currentCharge; }
		}

		public int Capacity
		{
			get { return MAX_CAPACITY; }
		}
	}
}

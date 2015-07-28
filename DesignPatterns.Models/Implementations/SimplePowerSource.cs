namespace DesignPatterns.Implementations
{
	public class SimplePowerSource : IPowerSource
	{
		private const int MAX_CAPACITY = 100;

		public SimplePowerSource()
		{
			CurrentCharge = 0;
		}

		public bool ProvidePower(int watts)
		{
			CurrentCharge -= watts;

			if (CurrentCharge <= 0)
			{
				CurrentCharge = 0;
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

			CurrentCharge += watts;
			if (CurrentCharge > MAX_CAPACITY)
			{
				CurrentCharge = MAX_CAPACITY;
			}

			return true;
		}

		public int CurrentCharge { get; private set; }

		public int Capacity
		{
			get { return MAX_CAPACITY; }
		}
	}
}
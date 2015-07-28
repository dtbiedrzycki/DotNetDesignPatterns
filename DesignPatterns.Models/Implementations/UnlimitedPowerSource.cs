using System;

namespace DesignPatterns.Implementations
{
	public class UnlimitedPowerSource : IPowerSource
	{
		public bool ProvidePower(int watts)
		{
			return true;
		}

		public bool Charge(int watts)
		{
			return true;
		}

		public int CurrentCharge
		{
			get { return Int32.MaxValue; }
		}

		public int Capacity
		{
			get { return Int32.MaxValue; }
		}
	}
}
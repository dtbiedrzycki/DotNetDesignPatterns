using System;
using System.Collections.Generic;

namespace DesignPatterns.Implementations
{
	public class Roboto : ICloneable
	{
		public IPowerSource PowerSource { get; set; }
		public List<IArm> Arms { get; set; }
		public IMobilitySystem MobilitySystem { get; set; }

		public object Clone()
		{
			return MemberwiseClone();
		}
	}
}
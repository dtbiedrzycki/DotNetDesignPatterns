using System;
using System.Collections.Generic;
using System.Text;

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

		public string GetStatus()
		{
			var output = new StringBuilder();

			output.AppendLine("=== ROBO INFO ===");
			output.AppendLine("=== Location ===");
			output.AppendLine(MobilitySystem.CurrentCoordinates.ToString());
			output.AppendLine("=== Arms INFO ===");
			for (int i = 0; i < Arms.Count; i++)
			{
				output.AppendLine(String.Format("=== Arm {0} INFO ===", i));
				output.AppendLine(Arms[i].CurrentCoordinates.ToString());
			}
			output.AppendLine("=== Power Source Info ===");
			output.AppendLine(String.Format("{0}/{1} Charged", PowerSource.CurrentCharge, PowerSource.Capacity));

			return output.ToString();
		}
	}
}
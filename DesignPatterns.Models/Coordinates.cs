using System;

namespace DesignPatterns
{
	public class Coordinates
	{
		public int X { get; set; }
		public int Y { get; set; }
		public int Z { get; set; }

		public override string ToString()
		{
			return String.Format("X:{0}, Y:{1}, Z:{2}", X, Y, Z);
		}
	}
}
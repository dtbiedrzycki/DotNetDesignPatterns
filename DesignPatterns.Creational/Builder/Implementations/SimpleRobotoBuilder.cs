using System.Collections.Generic;
using DesignPatterns;
using DesignPatterns.Implementations;

namespace BuilderPatterns.Builder.Implementations
{
	public class SimpleRobotoBuilder : IRobotoBuilder
	{
		private Roboto _roboto; 

		public void BuildNewRoboto()
		{
			_roboto = new Roboto()
			{
				PowerSource = new SimplePowerSource()
			};	
		}

		public void BuildArm()
		{
			if (_roboto != null)
			{
				var motor = new SimpleMotor(_roboto.PowerSource);
				var arm = new SimpleArm(motor);

				if (_roboto.Arms == null)
				{
					_roboto.Arms = new List<IArm>() { arm };
				}
				else
				{
					_roboto.Arms.Add(arm);
				}
			}
		}

		public void BuildMobilitySystem()
		{
			if (_roboto != null)
			{
				var motor = new SimpleMotor(_roboto.PowerSource);
				var mobilitySystem = new TreadMobilitySystem(motor);

				_roboto.MobilitySystem = mobilitySystem;
			}
		}

		public Roboto GetRoboto()
		{
			return _roboto == null ? null : (Roboto)_roboto.Clone();
		}
	}
}
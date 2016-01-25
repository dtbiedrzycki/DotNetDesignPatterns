using DesignPatterns;
using DesignPatterns.Implementations;
using System;
using System.Collections.Generic;

namespace BuilderPatterns.Builder.Implementations
{
	public class RobotoBuilder : IRobotoBuilder
	{
		private Roboto _roboto;

		public void CreateNewRoboto()
		{
			_roboto = new Roboto
			{
				Id = Guid.NewGuid(),
				Name = "Builder Roboto",
				PowerSource = new SimplePowerSource()
			};
		}

		public void AddArm()
		{
			if (_roboto != null)
			{
				var motor = new SimpleMotor(_roboto.PowerSource);
				var arm = new SimpleArm(motor);

				if (_roboto.Arms == null)
				{
					_roboto.Arms = new List<IArm> {arm};
				}
				else
				{
					_roboto.Arms.Add(arm);
				}
			}
		}

		public void AddMobilitySystem()
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
			return _roboto == null ? null : (Roboto) _roboto.Clone();
		}
	}
}
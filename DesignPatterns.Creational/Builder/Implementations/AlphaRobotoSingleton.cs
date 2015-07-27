using System;
using System.Collections.Generic;
using DesignPatterns;
using DesignPatterns.Implementations;

namespace BuilderPatterns.Builder.Implementations
{
	public class AlphaRobotoSingleton : Roboto
	{
		private static readonly Lazy<AlphaRobotoSingleton> _instance = new Lazy<AlphaRobotoSingleton>(
			() =>
			{
				var powerSource = new UnlimitedPowerSource();
				var roboto = new AlphaRobotoSingleton()
				{
					PowerSource =  powerSource,
					Arms = new List<IArm>()
					{
						new SimpleArm(new SimpleMotor(powerSource)),
						new SimpleArm(new SimpleMotor(powerSource))
					},
					MobilitySystem = new BipedalMobilitySystem(new SimpleMotor(powerSource))
				};

				return roboto;
			});

		public AlphaRobotoSingleton Instance()
		{
			return _instance.Value;
		}
	}
}

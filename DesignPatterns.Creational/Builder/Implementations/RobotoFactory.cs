using System.Collections.Generic;
using DesignPatterns;
using DesignPatterns.Implementations;

namespace BuilderPatterns.Builder.Implementations
{
	public class RobotoFactory : IRobotoFactory
	{
		public DesignPatterns.Implementations.Roboto CreateRollingRoboto()
		{
			var powerSource = new SimplePowerSource();
			var roboto = new Roboto()
			{
				PowerSource =  powerSource,
				Arms = new List<IArm>() { new SimpleArm(new SimpleMotor(powerSource)) },
				MobilitySystem = new TreadMobilitySystem(new SimpleMotor(powerSource))
			};

			return roboto;
		}

		public DesignPatterns.Implementations.Roboto CreateHumanoidRoboto()
		{
			var powerSource = new SimplePowerSource();
			var roboto = new Roboto()
			{
				PowerSource =  powerSource,
				Arms = new List<IArm>()
				{
					new SimpleArm(new SimpleMotor(powerSource)),
					new SimpleArm(new SimpleMotor(powerSource))
				},
				MobilitySystem = new BipedalMobilitySystem(new SimpleMotor(powerSource))
			};

			return roboto;;
		}
	}
}

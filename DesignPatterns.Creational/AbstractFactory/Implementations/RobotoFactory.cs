using DesignPatterns;
using DesignPatterns.Implementations;
using System;
using System.Collections.Generic;

namespace BuilderPatterns.AbstractFactory.Implementations
{
	public class RobotoFactory : IRobotoFactory
	{
		public Roboto CreateRollingRoboto()
		{
			var powerSource = new SimplePowerSource();
			var roboto = new Roboto
			{
				Id = Guid.NewGuid(),
				Name = "Rolling Roboto",
				PowerSource = powerSource,
				Arms = new List<IArm> {new SimpleArm(new SimpleMotor(powerSource))},
				MobilitySystem = new TreadMobilitySystem(new SimpleMotor(powerSource))
			};

			return roboto;
		}

		public Roboto CreateHumanoidRoboto()
		{
			var powerSource = new SimplePowerSource();
			var roboto = new Roboto
			{
				Id = Guid.NewGuid(),
				Name = "Humanoid Roboto",
				PowerSource = powerSource,
				Arms = new List<IArm>
				{
					new SimpleArm(new SimpleMotor(powerSource)),
					new SimpleArm(new SimpleMotor(powerSource))
				},
				MobilitySystem = new BipedalMobilitySystem(new SimpleMotor(powerSource))
			};

			return roboto;
		}
	}
}
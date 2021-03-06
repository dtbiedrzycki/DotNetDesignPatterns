﻿using DesignPatterns;
using DesignPatterns.Implementations;
using System;
using System.Collections.Generic;

namespace BuilderPatterns.Singleton
{
	/// <summary>
	/// A creational pattern in which only a single instance can exist
	/// </summary>
	public class AlphaRobotoSingleton : Roboto
	{
		private static readonly Lazy<AlphaRobotoSingleton> _instance = new Lazy<AlphaRobotoSingleton>(
			() =>
			{
				var powerSource = new UnlimitedPowerSource();
				var roboto = new AlphaRobotoSingleton
				{
					Id = Guid.NewGuid(),
					Name = "Alpha Roboto (Singleton)",
					PowerSource = powerSource,
					Arms = new List<IArm>
					{
						new SimpleArm(new SimpleMotor(powerSource)),
						new SimpleArm(new SimpleMotor(powerSource))
					},
					MobilitySystem = new BipedalMobilitySystem(new SimpleMotor(powerSource))
				};

				return roboto;
			});

		public static AlphaRobotoSingleton Instance()
		{
			return _instance.Value;
		}
	}
}